using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    public class ApunteSinIVA : A3ModelBase
    {
        [FixedLength(1, 1)]
        private int TipoFormato => 4;

        [FixedLength(2, 5, PaddingType.Left, '0')]
        public int CodigoEmpresa { get; set; }

        [FixedLength(7, 8)]
        public DateTime Fecha { get; set; }

        [FixedLength(15, 1)]
        private int TipoRegistro => 0;

        [FixedLength(16, 12, PaddingType.Right, ' ')]
        public string Cuenta { get; set; }

        [FixedLength(28, 30)]
        public string DescripcionCuenta { get; set; }

        [FixedLength(58, 1, FormatType.EnumDesc)]
        public TipoImporte TipoImporte { get; set; }

        [FixedLength(59, 10)]
        public string ReferenciaDocumento { get; set; }

        [FixedLength(69, 1)]
        private char TipoLinea { get; set; } = 'I';

        [FixedLength(70, 30)]
        public string DescripcionApunte { get; set; }

        [FixedLength(100, 14)]
        public decimal Importe { get; set; }

        [FixedLength(252, 1)]
        private char TieneRegistroAnalitico { get; } = 'N';

        [FixedLength(253, 1)]
        private char Moneda { get; } = 'E';

        [FixedLength(254, 1)]
        private char IndicadorGenerado { get; } = 'N';

        public string CuentaApunteContrario { get; set; }
        public string DescripcionCuentaApunteContrario { get; set; }

        internal ApunteSinIVA ObtenerApunteContrario()
        {
            var apunteContrario = (ApunteSinIVA)this.MemberwiseClone();

            apunteContrario.Cuenta = this.CuentaApunteContrario;
            apunteContrario.DescripcionCuenta = this.DescripcionCuentaApunteContrario;
            apunteContrario.TipoImporte = this.TipoImporte == TipoImporte.Debe ? TipoImporte.Haber : TipoImporte.Debe;
            apunteContrario.TipoLinea = 'U';

            return apunteContrario;
        }
    }
}
