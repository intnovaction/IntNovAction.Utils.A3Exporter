using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Helpers
{
    public class FixedLengthPropertyInfo
    {
        public PropertyInfo PropertyInfo { get; set; }

        public FixedLengthAttribute FixedLengthInfo { get; set; }

        public Func<object, string> StringValueFunction { get; set; }

        public void CopyToBuffer<T>(T data, byte[] buffer)
        {
            var value = this.PropertyInfo.GetValue(data);
            var strValue = this.StringValueFunction(value);

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
