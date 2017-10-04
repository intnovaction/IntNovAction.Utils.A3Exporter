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
            var cabeceraFactura = new Factura("2017/1002")
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 4, 26),
                Cuenta = "430010370000",                
                DescripcionCuenta = "Sociedad Cooperativa TEST1234",
                TipoFactura = TipoFactura.Ventas,
                DescripcionApunte = "Factura: 2017/1002",                               
                Importe = 4867.23M
            };  

            var expectedResult = "300135201704261430010370000Sociedad Cooperativa TEST1234 12017/1002 IFactura: 2017/1002            +0000004867.23                                                                                                                                           ES";

            var strResult = _writer.WriteLine(cabeceraFactura);

            strResult.Should().BeEquivalentTo(expectedResult);
            
        }

        [Fact]
        public void CheckWriter_LineaFactura_Cargo()
        {
            var lineaFactura = new LineaFactura
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 4, 26),
                Cuenta = "705100020000",
                DescripcionCuenta = "SERVICIOS JURIDICOS TEST123",
                TipoImporte = TipoImporteFactura.Cargo,
                NumeroFactura = "2017/1002",
                TipoLinea = TipoLineaFactura.Intermedia,
                DescripcionApunte = "(HN)Factura: 2017/1002",
                BaseImponible = 4022.50M,
                PorcentajeIVA = 21,
                CuotaIVA = 844.73M,
                OperacionSujetaIVA = true,

            };

            var expectedResult = "300135201704269705100020000SERVICIOS JURIDICOS TEST123   C2017/1002 M(HN)Factura: 2017/1002        01+0000004022.5021.00+0000000844.7300.00+0000000000.0000.00+0000000000.0001S                                                                            NES";

            var strResult = _writer.WriteLine(lineaFactura);

            strResult.Should().BeEquivalentTo(expectedResult);

        }

        [Fact]
        public void CheckWriter_LineaFactura_Abono()
        {
            var lineaFactura = new LineaFactura
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 4, 26),
                Cuenta = "561010370000",
                DescripcionCuenta = "Sociedad Cooperativa TEST1234",
                TipoImporte = TipoImporteFactura.Abono,
                NumeroFactura = "2017/1002",
                TipoLinea = TipoLineaFactura.Intermedia,
                DescripcionApunte = "Provisiones de: 2017/1002",
                BaseImponible = 1763.87M,
                OperacionSujetaIVA = false,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias

            };

            var expectedResult = "300135201704269561010370000Sociedad Cooperativa TEST1234 A2017/1002 MProvisiones de: 2017/1002     01+0000001763.8700.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            NES";
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
                DescripcionCuenta = "DESCRIPCION CUENTA PROVEED",
                ActualizarSaldoInicial = false,
                NIF = "B12x52671",
                ViaPublica = "Direaccion test 132, plaza 123",
                Municipio = "MUNIC",
                CodigoPostal = "32619",
                Provincia = "Ourense",
                Telefono = "988888888",
                Fax = "988777777"
            };

            var expectedResult = "30013520170101C430010010000DESCRIPCION CUENTA PROVEED    N+0000000000.00     B12x52671       Direaccion test 132, plaza 123           MUNIC               32619Ourense           988888888       988777777                                                  ES";
            var strResult = _writer.WriteLine(cuentaProveedor);

            strResult.Should().BeEquivalentTo(expectedResult);

        }


    }
}
