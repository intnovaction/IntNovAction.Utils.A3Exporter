using IntNovAction.Utils.A3Exporter.A3Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    /// <summary>
    /// Representación de bool en fichero A3
    /// </summary>
    internal class A3BoolDataFormatter : IA3DataFormatter
    {
        public TypeCode TypeCode => TypeCode.Boolean;
        public Func<object, FormatType, string> Formatter => (objValue, formatType) => {
            return ((bool)objValue) ? "S" : "N";
        };
    }
}
