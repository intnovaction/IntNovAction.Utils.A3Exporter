using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    internal class A3DecimalDataFormatter : IA3DataFormatter
    {
        public TypeCode TypeCode => TypeCode.Decimal;
        public Func<object, string> Formatter => (objValue) => {
            return ((decimal)objValue).ToString("+0000000000.00;-0000000000.00", System.Globalization.CultureInfo.InvariantCulture);
        };
    }
}
