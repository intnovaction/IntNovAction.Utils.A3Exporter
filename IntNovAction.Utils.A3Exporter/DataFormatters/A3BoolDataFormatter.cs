using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    internal class A3BoolDataFormatter : IA3DataFormatter
    {
        public TypeCode TypeCode => TypeCode.Boolean;
        public Func<object, string> Formatter => (objValue) => {
            return ((bool)objValue) ? "S" : "N";
        };
    }
}
