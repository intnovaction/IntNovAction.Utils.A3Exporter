using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    internal class A3IntEnumDataFormatter : IA3DataFormatter
    {
        public TypeCode TypeCode => TypeCode.Int32;

        public Func<object, string> Formatter => (objValue) => {
            return ((int)objValue).ToString();
        };
    }
}
