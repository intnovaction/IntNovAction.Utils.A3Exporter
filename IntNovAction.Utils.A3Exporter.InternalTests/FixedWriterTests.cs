using FluentAssertions;
using IntNovAction.Utils.A3Exporter.A3Models;
using IntNovAction.Utils.A3Exporter.Helpers;
using System;
using Xunit;


namespace IntNovAction.Utils.A3Exporter.InternalTests
{
    public class FixedWriterTests
    {

        private FixedLengthWriter _writer;

        public FixedWriterTests()
        {
            _writer = new FixedLengthWriter();
        }

        [Fact]
        public void CheckWriter_CabeceraFactura()
        {
            var cabeceraFactura = new Factura("2018/9000")
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "43042486",
                DescripcionCuenta = "TRANSPORTES Y EXCAVACIONES REC",
                TipoFactura = TipoFactura.Ventas,
                DescripcionApunte = "Factura: 2018/9000",
                Importe = 4867.23M
            };  

            var expectedResult = "50099920180508143042486    TRANSPORTES Y EXCAVACIONES REC12018/9000 IFactura: 2018/9000            +0000004867.23                                                                                                                                           2018/9000                                                                                                                                                                                                                                                       EN";

            var strResult = _writer.WriteLine(cabeceraFactura);

            strResult.Should().BeEquivalentTo(expectedResult);
            
        }

        [Fact]
        public void CheckWriter_LineaFactura_Cargo()
        {
            var lineaFactura = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "70580001",
                DescripcionCuenta = "CUENTA 2",
                TipoImporte = TipoImporteFactura.Cargo,
                NumeroFactura = "2018/9000",
                TipoLinea = TipoLineaFactura.Intermedia,
                DescripcionApunte = "(HN)Factura: 2018/9000",
                BaseImponible = 4022.50M,
                PorcentajeIVA = 21,
                CuotaIVA = 844.73M,
                OperacionSujetaIVA = true,

            };

            var expectedResult = "50099920180508970580001    CUENTA 2                      C2018/9000 M(HN)Factura: 2018/9000        01+0000004022.5021.00+0000000844.7300.00+0000000000.0000.00+0000000000.0001S                                                                            N                                                                                                                                                                                                                                                                EN";                

            var strResult = _writer.WriteLine(lineaFactura);

            strResult.Should().BeEquivalentTo(expectedResult);

        }

        [Fact]
        public void CheckWriter_LineaFactura_Abono()
        {
            var lineaFactura = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "56101037",
                DescripcionCuenta = "Sociedad Cooperativa TEST1234",
                TipoImporte = TipoImporteFactura.Abono,
                NumeroFactura = "2018/9000",
                TipoLinea = TipoLineaFactura.Intermedia,
                DescripcionApunte = "Provisiones de: 2018/9000",
                BaseImponible = 1763.87M,
                OperacionSujetaIVA = false,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias

            };

            var expectedResult = "50099920180508956101037    Sociedad Cooperativa TEST1234 A2018/9000 MProvisiones de: 2018/9000     01+0000001763.8700.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            N                                                                                                                                                                                                                                                                EN";
            var strResult = _writer.WriteLine(lineaFactura);

            strResult.Should().BeEquivalentTo(expectedResult);

        }

        [Fact]
        public void CheckWriter_CuentaProveedor()
        {
            var cuentaProveedor = new CuentaProveedor
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 01, 01),
                Cuenta = "430010010000",
                DescripcionCuenta = "DESCRIPCIÓN CUENTA PROVEED",
                ActualizarSaldoInicial = false,
                NIF = "B12x52671",
                ViaPublica = "Direaccion test 132, plaza 123",
                Municipio = "MUNIC",
                CodigoPostal = "32619",
                Provincia = "Ourense",
                Telefono = "988888888",
                Fax = "988777777"
            };

            var expectedResult = "50013520170101C430010010000DESCRIPCION CUENTA PROVEED    N+0000000000.00     B12x52671       Direaccion test 132, plaza 123           MUNIC               32619Ourense           988888888       988777777                                                                                                                                                                                                                                                                                                                  EN";
            var strResult = _writer.WriteLine(cuentaProveedor);

            strResult.Should().BeEquivalentTo(expectedResult);

        }


    }
}
