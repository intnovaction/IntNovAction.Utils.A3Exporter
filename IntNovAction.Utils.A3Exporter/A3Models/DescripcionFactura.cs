using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    public class DescripcionFactura : A3ModelBase
    {
        [FixedLength(1, 1)]
        private int TipoFormato => 5;

        [FixedLength(2, 5, PaddingType.Left, '0')]
        public int CodigoEmpresa { get; set; }

        [FixedLength(7, 8)]
        public DateTime Fecha { get; set; }

        [FixedLength(15, 1)]
        private int TipoRegistro => 5;

        [FixedLength(59, 451)]
        public string Descripcion { get; set; }

        [FixedLength(509, 1)]
        private char Moneda { get; } = 'E';

        [FixedLength(510, 1)]
        private char IndicadorGenerado { get; } = 'N';
    }
}
