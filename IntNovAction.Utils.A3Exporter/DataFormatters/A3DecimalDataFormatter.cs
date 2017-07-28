using IntNovAction.Utils.A3Exporter.A3Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    /// <summary>
    /// Representación de decimales en fichero A3
    /// Dos opciones:
    /// - General: es un importe: +0000000000.00
    /// - Porcentaje: 00.00
    /// </summary>
    internal class A3DecimalDataFormatter : IA3DataFormatter
    {
        public TypeCode TypeCode => TypeCode.Decimal;
        public Func<object, FormatType, string> Formatter => (objValue, formatType) => {
            if (formatType == FormatType.Percent)
            {
                return ((decimal)objValue).ToString("00.00", System.Globalization.CultureInfo.InvariantCulture);
            }

            return ((decimal)objValue).ToString("+0000000000.00;-0000000000.00", System.Globalization.CultureInfo.InvariantCulture);
        };
    }
}
