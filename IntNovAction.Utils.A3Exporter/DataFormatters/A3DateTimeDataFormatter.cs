using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    internal class A3DateTimeDataFormatter : IA3DataFormatter
    {
        public TypeCode TypeCode => TypeCode.DateTime;
        public Func<object, string> Formatter => (objValue) => {
            return ((DateTime)objValue).ToString("yyyyMMdd");
        };
    }
}
