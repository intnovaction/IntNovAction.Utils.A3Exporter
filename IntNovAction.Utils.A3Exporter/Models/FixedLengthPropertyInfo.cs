using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using IntNovAction.Utils.A3Exporter.DataFormatters;
using IntNovAction.Utils.A3Exporter.A3Models;

namespace IntNovAction.Utils.A3Exporter.Models
{
    /// <summary>
    /// Contiene los datos necesarios para el formateo de una propiedad en texto para el fichero A3
    /// </summary>
    internal class FixedLengthPropertyInfo
    {
        internal PropertyInfo PropertyInfo { get; set; }

        internal FixedLengthAttribute FixedLengthInfo { get; set; }

        internal Func<object, FormatType, string> StringValueFunction { get; set; }

        internal void CopyToBuffer<T>(T data, byte[] buffer)
        {
            var value = this.PropertyInfo.GetValue(data);
            var strValue = this.StringValueFunction(value, this.FixedLengthInfo.FormatType);

            if (this.FixedLengthInfo.Length < strValue.Length)
            {
                strValue = strValue.Substring(0, this.FixedLengthInfo.Length);
            }
            else
            {
                strValue = this.FixedLengthInfo.PaddingType == PaddingType.Left ?
                    strValue.PadLeft(this.FixedLengthInfo.Length, this.FixedLengthInfo.PaddingChar) :
                    strValue.PadRight(this.FixedLengthInfo.Length, this.FixedLengthInfo.PaddingChar);
            }

            var byteValue = ASCIIEncoding.ASCII.GetBytes(strValue);
            byteValue.CopyTo(buffer, this.FixedLengthInfo.Index - 1);

        }
    }
}
