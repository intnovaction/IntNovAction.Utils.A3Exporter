using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    /// <summary>
    /// Datos de línea de factura
    /// </summary>
    public class LineaFactura : A3ModelBase
    {
        [FixedLength(1, 1)]
        private int TipoFormato => 5;

        [FixedLength(2, 5, PaddingType.Left, '0')]
        public int CodigoEmpresa { get; set; }

        [FixedLength(7, 8)]
        public DateTime Fecha { get; set; }

        [FixedLength(15, 1)]
        protected int TipoRegistro => 9;

        [FixedLength(16, 12, PaddingType.Right, ' ')]
        public string Cuenta { get; set; }
        
        [FixedLength(28, 30)]
        public string DescripcionCuenta { get; set; }

        [FixedLength(58, 1, FormatType.EnumDesc)]
        public TipoImporteFactura TipoImporte { get; set; }

        [FixedLength(59, 10)]
        internal string NumeroFactura { get; set; }

        [FixedLength(69, 1, FormatType.EnumDesc)]
        internal TipoLineaFactura TipoLinea { get; set; }

        [FixedLength(70, 30)]
        public string DescripcionApunte { get; set; }

        [FixedLength(100, 2, PaddingType.Left, '0')]
        public SubtipoFactura SubtipoFactura { get; set; } = SubtipoFactura.OperacionSujetaIVA;

        [FixedLength(102, 14)]
        public decimal BaseImponible { get; set; }

        [FixedLength(116, 5, FormatType.Percent)]
        public decimal PorcentajeIVA { get; set; }

        [FixedLength(121, 14)]
        internal decimal CuotaIVA { get; set; }

        [FixedLength(135, 5, FormatType.Percent)]
        public decimal PorcentajeRecargo { get; set; }

        [FixedLength(140, 14)]
        internal decimal CuotaRecargo { get; set; }

        [FixedLength(154, 5, FormatType.Percent)]
        public decimal PorcentajeRetencion { get; set; }

        [FixedLength(159, 14)]
        internal decimal CuotaRetencion { get; set; }

        [FixedLength(173, 2, PaddingType.Left, '0')]
        public TipoImpreso TipoImpreso { get; set; } = TipoImpreso.Impreso_347;

        [FixedLength(175, 1)]
        internal bool OperacionSujetaIVA { get; set; }

        [FixedLength(176, 1)]
        public bool? AfectaModelo415 { get; set; }

        [FixedLength(177, 1)]
        public bool? MarcaFacturaCriterioCaja { get; set; }

        [FixedLength(192, 12)]
        public string CuentaIVA { get; set; }

        [FixedLength(204, 12)]
        public string CuentaRecargo { get; set; }

        [FixedLength(216, 12)]
        public string CuentaRetencion { get; set; }

        [FixedLength(228, 12)]
        public string CuentaIVA2 { get; set; }

        [FixedLength(240, 12)]
        public string CuentaRecargo2 { get; set; }


        [FixedLength(252, 1)]
        public bool RegistroAnalitico { get; set; } = false;

        [FixedLength(509, 1)]
        private char Moneda { get; } = 'E';

        [FixedLength(510, 1)]
        private char IndicadorGenerado { get; } = 'N';


        /// <summary>
        /// Indica q es una linea de regularización (para hacer que cuadre en caso de meter suplidos o provisiones) y que se pone para igualar a cero.
        /// </summary>
        public bool EsRegularizacion { get; set; } = false;
    }
}
