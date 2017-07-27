using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Helpers
{
    public static class FixedLengthWriter
    {
        private static Dictionary<string, FixedLengthClassInfo> FixedLengthClassDictionary = new Dictionary<string, FixedLengthClassInfo>();

        public static string WriteLine<T>(T data)
        {
            var result = string.Empty;

            var typeName = typeof(T).Name;

            if (!FixedLengthClassDictionary.ContainsKey(typeName))
            {
                FixedLengthClassDictionary.Add(typeName, GetFixedLengthClassInfo(data));
            }

            var fixedLengthClass = FixedLengthClassDictionary[typeName];

            if (fixedLengthClass.LineLength == 0)
            {
                return string.Empty;
            }
            
            byte[] buffer = new byte[fixedLengthClass.LineLength];
            for (var i = 0; i < buffer.Length;i++)
            {
                buffer[i] = (byte)' ';
            }

            foreach (var property in fixedLengthClass.Properties)
            {
                property.CopyToBuffer(data, buffer);
            }

            result = ASCIIEncoding.ASCII.GetString(buffer).Trim(new char[] { '\0' });
            return result;
        }

        private static FixedLengthClassInfo GetFixedLengthClassInfo<T>(T data)
        {
            var fixedLengthClassInfo = new FixedLengthClassInfo();

            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Select(p =>
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

            fixedLengthClassInfo.Properties = properties.Select(p => new FixedLengthPropertyInfo {
                PropertyInfo = p.PropertyInfo,
                FixedLengthInfo = p.Attribute,
                StringValueFunction = GetStrFunction(p.PropertyInfo)
            }).ToList();


            return fixedLengthClassInfo;
        }

        private static Func<object, string> GetStrFunction(PropertyInfo property)
        {
            var propertyType = Type.GetTypeCode(property.PropertyType);

            switch (propertyType)
            {
                case TypeCode.Decimal:
                    return (objValue) => { return ((decimal)objValue).ToA3String(); };
                case TypeCode.Boolean:
                    return (objValue) => { return ((bool)objValue).ToA3String(); };
                case TypeCode.DateTime:
                    return (objValue) => { return ((DateTime)objValue).ToA3String(); };
                case TypeCode.Int32:
                    return (objValue) => { return ((int)objValue).ToA3String(); };
                default:
                    return (objValue) => { return objValue.ToA3String(); };
            }


        }

    }
}
