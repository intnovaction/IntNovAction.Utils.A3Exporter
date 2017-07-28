using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.DataFormatters
{
    internal interface IA3DataFormatter
    {
        TypeCode TypeCode { get; }

        Func<object, string> Formatter { get; }
    }
}
