using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    public class CabeceraFactura : A3ModelBase
    {

        [FixedLength(1, 1)]
        private int TipoFormato => 4;

        [FixedLength(2, 5, PaddingType.Left, '0')]
        public int CodigoEmpresa { get; set; }

        [FixedLength(7, 8)]
        public DateTime Fecha { get; set; }

        [FixedLength(15, 1)]
        protected int TipoRegistro => 1;

        [FixedLength(16, 12, PaddingType.Right, '0')]
        public string Cuenta { get; set; }

        [FixedLength(28, 30)]
        public string DescripcionCuenta { get; set; }

        [FixedLength(58, 1)]
        public TipoFactura TipoFactura { get; set; }

        [FixedLength(59, 10)]
        public string NumeroFactura { get; set; }

        [FixedLength(69, 1)]
        private char LineaApunte { get; } = 'I';

        [FixedLength(70, 30)]
        public string DescripcionApunte { get; set; }

        [FixedLength(100, 14)]
        public decimal Importe { get; set; }

        [FixedLength(176, 14)]
        public string NIF { get; set; }

        public List<LineaFactura> Lineas { get; set; }

        
    }
}
