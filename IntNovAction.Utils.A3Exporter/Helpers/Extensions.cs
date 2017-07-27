using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Helpers
{
    public static class Extensions
    {
        public static string ToA3String(this DateTime dateValue)
        {
            return dateValue.ToString("yyyyMMdd");
        }

        public static string ToA3String(this decimal decimalValue)
        {
            return decimalValue.ToString("+0000000000.00;-0000000000.00", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string ToA3String(this bool boolValue)
        {
            return boolValue ? "S" : "N";
        }

        public static string ToA3String(this object obj)
        {
            return obj.ToString();
        }

    }
}
