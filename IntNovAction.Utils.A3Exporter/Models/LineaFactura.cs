using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Models
{
    public class LineaFactura
    {
        [FixedLength(1, 1)]
        private int TipoFormato => 4;

        [FixedLength(2, 5, PaddingType.Left, '0')]
        public int CodigoEmpresa { get; set; }

        [FixedLength(7, 8)]
        public DateTime Fecha { get; set; }

        [FixedLength(15, 1)]
        protected int TipoRegistro => 9;
    }
}
