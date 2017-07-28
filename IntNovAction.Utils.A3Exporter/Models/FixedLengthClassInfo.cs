using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Models
{
    /// <summary>
    /// Contiene la información de una clase que se puede formatear como una línea de fichero A3
    /// </summary>
    internal class FixedLengthClassInfo
    {
        internal int LineLength { get; set; }

        internal List<FixedLengthPropertyInfo> Properties { get; set; } = new List<FixedLengthPropertyInfo>();
    }
}
