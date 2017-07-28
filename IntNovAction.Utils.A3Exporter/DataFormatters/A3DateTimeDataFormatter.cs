using IntNovAction.Utils.A3Exporter.A3Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    /// <summary>
    /// Representación de fechas en fichero A3
    /// </summary>
    internal class A3DateTimeDataFormatter : IA3DataFormatter
    {
        public TypeCode TypeCode => TypeCode.DateTime;
        public Func<object, FormatType, string> Formatter => (objValue, formatType) => {
            return ((DateTime)objValue).ToString("yyyyMMdd");
        };
    }
}
