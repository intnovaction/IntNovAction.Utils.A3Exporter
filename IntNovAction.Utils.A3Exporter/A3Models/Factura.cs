using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    /// <summary>
    /// Datos de factura
    /// </summary>
    public class Factura : A3ModelBase
    {

        [FixedLength(1, 1)]
        private int TipoFormato => 3;

        [FixedLength(2, 5, PaddingType.Left, '0')]
        public int CodigoEmpresa { get; set; }

        [FixedLength(7, 8)]
        public DateTime Fecha { get; set; }

        [FixedLength(15, 1)]
        private int TipoRegistro => 1;

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

        [FixedLength(190, 40)]
        public string NombreCliente { get; set; }

        [FixedLength(230, 5)]
        public string CodigoPostal { get; set; }

        [FixedLength(237, 8)]
        public DateTime? FechaOperacion { get; set; }

        [FixedLength(245, 8)]
        public DateTime? FechaFactura { get; set; }

        [FixedLength(253, 1)]
        private char Moneda { get; } = 'E';

        [FixedLength(254, 1)]
        private char IndicadorGenerado { get; } = 'S';

        internal List<LineaFactura> Lineas { get; set; }

        public Factura(string numeroFactura)
        {
            this.NumeroFactura = numeroFactura;
            this.Lineas = new List<LineaFactura>();
        }

        public void AddLineaFactura(LineaFactura linea)
        {
            linea.CuotaIVA = Math.Round(linea.BaseImponible * linea.PorcentajeIVA / 100, 2, MidpointRounding.AwayFromZero);
            linea.CuotaRecargo = Math.Round(linea.BaseImponible * linea.PorcentajeRecargo / 100, 2, MidpointRounding.AwayFromZero);
            linea.CuotaRetencion = Math.Round(linea.BaseImponible * linea.PorcentajeRetencion / 100, 2, MidpointRounding.AwayFromZero);

            linea.OperacionSujetaIVA = linea.PorcentajeIVA > 0;
            linea.TipoLinea = TipoLineaFactura.Ultima;
            linea.NumeroFactura = this.NumeroFactura;

            if (this.Lineas.Count > 0)
            {
                Lineas[Lineas.Count - 1].TipoLinea = TipoLineaFactura.Intermedia;
            }

            Lineas.Add(linea);
        }
        
    }
}
