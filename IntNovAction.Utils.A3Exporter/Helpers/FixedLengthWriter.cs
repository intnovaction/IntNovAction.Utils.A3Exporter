using IntNovAction.Utils.A3Exporter.A3Models;
using IntNovAction.Utils.A3Exporter.Attributes;
using IntNovAction.Utils.A3Exporter.DataFormatters;
using IntNovAction.Utils.A3Exporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Helpers
{
    public static class FixedLengthWriter
    {
        private static Dictionary<string, FixedLengthClassInfo> _fixedLengthClassDictionary = new Dictionary<string, FixedLengthClassInfo>();        

        static FixedLengthWriter()
        {
            var formattersDictionary = GetFormatters();
            _fixedLengthClassDictionary = GetFixedLengthClassesInfo(formattersDictionary);
        }

        internal static string WriteLine<T>(T data) where T : A3ModelBase
        {
            var result = string.Empty;

            var typeName = typeof(T).Name;

            var fixedLengthClass = _fixedLengthClassDictionary[typeName];

            if (fixedLengthClass.LineLength == 0)
            {
                return string.Empty;
            }

            byte[] buffer = GetEmptyBuffer(fixedLengthClass);

            foreach (var property in fixedLengthClass.Properties)
            {
                property.CopyToBuffer(data, buffer);
            }

            result = ASCIIEncoding.ASCII.GetString(buffer);
            return result;
        }

        private static byte[] GetEmptyBuffer(FixedLengthClassInfo fixedLengthClass)
        {
            byte[] buffer = new byte[fixedLengthClass.LineLength];
            for (var i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)' ';
            }

            return buffer;
        }

        private static Dictionary<TypeCode, Func<object, string>> GetFormatters()
        {
            var a3DataFormatterType = typeof(IA3DataFormatter);

            var formattersDictionary = a3DataFormatterType.GetTypeInfo().Assembly.GetTypes()
                .Where(t => t != a3DataFormatterType && a3DataFormatterType.IsAssignableFrom(t))
                .Select(t => (IA3DataFormatter)Activator.CreateInstance(t))
                .ToDictionary(i => i.TypeCode, i => i.Formatter);

            return formattersDictionary;
        }

        private static Dictionary<string, FixedLengthClassInfo> GetFixedLengthClassesInfo(Dictionary<TypeCode, Func<object, string>> formatters)
        {
            var a3ModelType = typeof(A3ModelBase);

            var types = a3ModelType.GetTypeInfo().Assembly.GetTypes()
                .Where(t => a3ModelType != t && a3ModelType.IsAssignableFrom(t));

            var classesInfoDictionary = types.ToDictionary(t => t.Name, t => GetFixedLengthClassInfo(t, formatters));

            return classesInfoDictionary;
        }

        private static FixedLengthClassInfo GetFixedLengthClassInfo(Type a3ModelType, Dictionary<TypeCode, Func<object, string>> formatters)
        {
            var fixedLengthClassInfo = new FixedLengthClassInfo();

            var properties = a3ModelType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Select(p =>
                new
                {
                    PropertyInfo = p,
                    Attribute = (p.GetCustomAttribute(typeof(FixedLengthAttribute)) as FixedLengthAttribute)
                })
                .Where(p => p.Attribute != null)
                .ToList();

            if (!properties.Any())
            {
                return fixedLengthClassInfo;
            }

            fixedLengthClassInfo.LineLength = properties.Max(p => p.Attribute.Index + p.Attribute.Length) - 1;
            foreach (var property in properties)
            {
                var fixedLengthPropertyInfo = new FixedLengthPropertyInfo
                {
                    PropertyInfo = property.PropertyInfo,
                    FixedLengthInfo = property.Attribute
                };

                var typeCode = Type.GetTypeCode(property.PropertyInfo.PropertyType);
                fixedLengthPropertyInfo.StringValueFunction = formatters.ContainsKey(typeCode) ? formatters[typeCode] : DefaultStringFormatter;

                fixedLengthClassInfo.Properties.Add(fixedLengthPropertyInfo);
            }


            return fixedLengthClassInfo;
        }

        private static string DefaultStringFormatter(object value)
        {
            return value.ToString();
        }

    }
}
