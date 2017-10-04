using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    /// <summary>
    /// Tipos de línea de factura
    /// </summary>
    internal enum TipoLineaFactura
    {
        [Description("M")]
        Intermedia = 1,
        [Description("U")]
        Ultima = 2
    }
}
