using IntNovAction.Utils.A3Exporter.A3Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    /// <summary>
    /// Representación de enumerados en fichero de A3. 
    /// Dos opciones:
    /// - General: imprime el entero correspondiente al enumerado
    /// - EnumDesc: imprime el valor del atributo Description del enumerado
    /// </summary>
    internal class A3IntEnumDataFormatter : IA3DataFormatter
    {
        public TypeCode TypeCode => TypeCode.Int32;

        public Func<object, FormatType, string> Formatter => (objValue, formatType) => {
            if (formatType == FormatType.EnumDesc)
            {
                return GetEnumDescription(objValue);
            }
            return ((int)objValue).ToString();
        };


        internal static string GetEnumDescription(object value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
