using IntNovAction.Utils.A3Exporter.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    /// <summary>
    /// Datos de la cuenta de un proveedor
    /// </summary>
    public class CuentaProveedor : A3ModelBase
    {
        [FixedLength(1, 1)]
        private int TipoFormato => 3;

        [FixedLength(2, 5, PaddingType.Left, '0')]
        public int CodigoEmpresa { get; set; }

        [FixedLength(7, 8)]
        public DateTime Fecha { get; set; }

        [FixedLength(15, 1)]
        private char TipoRegistro => 'C';

        [FixedLength(16, 12, PaddingType.Right, '0')]
        public string Cuenta { get; set; }

        [FixedLength(28, 30)]
        public string DescripcionCuenta { get; set; }

        [FixedLength(58, 1)]
        public bool ActualizarSaldoInicial { get; set; }

        [FixedLength(59, 14)]
        public decimal SaldoInicial { get; set; }

        [FixedLength(73, 1)]
        private char Ampliacion => ' ';

        [FixedLength(78, 14)]
        public string NIF { get; set; }

        [FixedLength(92, 2)]
        public string SiglasViaPublica { get; set; }

        [FixedLength(94, 30)]
        public string ViaPublica { get; set; }

        [FixedLength(124, 5)]
        public string Numero { get; set; }

        [FixedLength(129, 2)]
        public string Escalera { get; set; }

        [FixedLength(131, 2)]
        public string Piso { get; set; }

        [FixedLength(133, 2)]
        public string Puerta { get; set; }

        [FixedLength(135, 20)]
        public string Municipio { get; set; }

        [FixedLength(155, 5)]
        public string CodigoPostal { get; set; }

        [FixedLength(160, 15)]
        public string Provincia { get; set; }

        [FixedLength(175, 3)]
        public string Pais { get; set; }

        [FixedLength(178, 12)]
        public string Telefono { get; set; }

        [FixedLength(190, 4)]
        public string Extension { get; set; }

        [FixedLength(194, 12)]
        public string Fax { get; set; }

        [FixedLength(206, 30)]
        public string Email { get; set; }

        [FixedLength(238, 1)]
        public bool? CriterioCaja { get; set; }

        [FixedLength(253, 1)]
        private char Moneda { get; } = 'E';

        [FixedLength(254, 1)]
        private char IndicadorGenerado { get; } = 'S';

    }
}
