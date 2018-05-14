using FluentAssertions;
using IntNovAction.Utils.A3Exporter.A3Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace IntNovAction.Utils.A3Exporter.Tests
{
    public class A3ExporterTest
    {


        [Fact]
        public void A3Exporter_Factura()
        {
            var factura = new Factura("2018/9000")
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "43042486",
                DescripcionCuenta = "TRANSPORTES Y EXCAVACIONES REC",
                TipoFactura = TipoFactura.Ventas,
                DescripcionApunte = "Factura: 2018/9000",
                Importe = 4867.23M
            };

            var linea1 = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "70580001",
                DescripcionCuenta = "CUENTA 2",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "(HN)Factura: 2018/9000",
                BaseImponible = 4022.5M,
                PorcentajeIVA = 21,
                TipoImpreso = TipoImpreso.Impreso_347
            };

            factura.AddLineaFactura(linea1);

            var linea2 = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "56601037",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "Suplidos de: 2018/9000",
                BaseImponible = 650,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea2);

            var linea3 = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "56101037",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Abono,
                DescripcionApunte = "Provisiones de: 2018/9000",
                BaseImponible = 1763.87M,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea3);

            var linea4 = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "43001037",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "Regularizacion de: 2018/9000",
                BaseImponible = 1113.87M,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea4);

            var expectedResults = new List<string>() {
                "50099920180508143042486    TRANSPORTES Y EXCAVACIONES REC12018/9000 IFactura: 2018/9000            +0000004867.23                                                                                                                                           2018/9000                                                                                                                                                                                                                                                       EN",
                "50099920180508970580001    CUENTA 2                      C2018/9000 M(HN)Factura: 2018/9000        01+0000004022.5021.00+0000000844.7300.00+0000000000.0000.00+0000000000.0001S                                                                            N                                                                                                                                                                                                                                                                EN",
                "50099920180508956601037    Test Nombre cuenta            C2018/9000 MSuplidos de: 2018/9000        01+0000000650.0000.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            N                                                                                                                                                                                                                                                                EN",
                "50099920180508956101037    Test Nombre cuenta            A2018/9000 MProvisiones de: 2018/9000     01+0000001763.8700.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            N                                                                                                                                                                                                                                                                EN",
                "50099920180508943001037    Test Nombre cuenta            C2018/9000 URegularizacion de: 2018/9000  01+0000001113.8700.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            N                                                                                                                                                                                                                                                                EN"
            };

            var exporter = new A3Exporter();
            var results = exporter.ExportarFactura(factura);

            results.Count.Should().Be(expectedResults.Count);
            for (var i = 0; i < expectedResults.Count; i++)
            {
                results[i].Should().BeEquivalentTo(expectedResults[i]);
            }

        }

        [Fact]
        public void A3Exporter_Factura_DescripcionLarga()
        {
            var factura = new Factura("2018/9000")
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "43042486",
                DescripcionCuenta = "TRANSPORTES Y EXCAVACIONES REC",
                TipoFactura = TipoFactura.Ventas,
                DescripcionApunte = "Factura: 2018/9000. Esta factura contiene una descripción larga, por lo que necesita una línea adicional",
                Importe = 4867.23M
            };

            var linea1 = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "70580001",
                DescripcionCuenta = "CUENTA 2",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "(HN)Factura: 2018/9000",
                BaseImponible = 4022.5M,
                PorcentajeIVA = 21,
                TipoImpreso = TipoImpreso.Impreso_347
            };

            factura.AddLineaFactura(linea1);

            var linea2 = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "56601037",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "Suplidos de: 2018/9000",
                BaseImponible = 650,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea2);

            var linea3 = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "56101037",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Abono,
                DescripcionApunte = "Provisiones de: 2018/9000",
                BaseImponible = 1763.87M,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea3);

            var linea4 = new LineaFactura
            {
                CodigoEmpresa = 999,
                Fecha = new DateTime(2018, 5, 8),
                Cuenta = "43001037",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "Regularizacion de: 2018/9000",
                BaseImponible = 1113.87M,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea4);

            var expectedResults = new List<string>() {
                "50099920180508143042486    TRANSPORTES Y EXCAVACIONES REC12018/9000 IFactura: 2018/9000. Esta factu+0000004867.23                                                                                                                                           2018/9000                                                                                                                                                                                                                                                       EN",
                "50099920180508970580001    CUENTA 2                      C2018/9000 M(HN)Factura: 2018/9000        01+0000004022.5021.00+0000000844.7300.00+0000000000.0000.00+0000000000.0001S                                                                            N                                                                                                                                                                                                                                                                EN",
                "50099920180508956601037    Test Nombre cuenta            C2018/9000 MSuplidos de: 2018/9000        01+0000000650.0000.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            N                                                                                                                                                                                                                                                                EN",
                "50099920180508956101037    Test Nombre cuenta            A2018/9000 MProvisiones de: 2018/9000     01+0000001763.8700.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            N                                                                                                                                                                                                                                                                EN",
                "50099920180508943001037    Test Nombre cuenta            C2018/9000 URegularizacion de: 2018/9000  01+0000001113.8700.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            N                                                                                                                                                                                                                                                                EN",
                "500999201805085                                           Factura: 2018/9000. Esta factura contiene una descripcion larga, por lo que necesita una linea adicional                                                                                                                                                                                                                                                                                                                                                          EN"                
            };

            var exporter = new A3Exporter();
            var results = exporter.ExportarFactura(factura);

            results.Count.Should().Be(expectedResults.Count);
            for (var i = 0; i < expectedResults.Count; i++)
            {
                results[i].Should().BeEquivalentTo(expectedResults[i]);
            }
            
        }

        [Fact]
        public void A3Exporter_CuentaProveedor()
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

            var expectedResult = "50013520170101C430010010000DESCRIPCION CUENTA PROVEED    N+0000000000.00     B12x52671       Direaccion test 132, plaza 123           MUNIC               32619Ourense           988888888       988777777                                                                                                                                                                                                                                                                                                                  EN";

            var exporter = new A3Exporter();
            var strResult = exporter.ExportarCuentaProveedor(cuentaProveedor);

            strResult.Should().BeEquivalentTo(expectedResult);
        }


        [Fact]
        public void A3Exporter_ApunteSinIVA()
        {

            var apunteSinIVA = new ApunteSinIVA
            {
                CodigoEmpresa = 1,
                Fecha = new DateTime(2017, 1, 1),
                Cuenta = "57000000",
                CuentaApunteContrario = "57200000",
                DescripcionCuenta = "DESCRIPCION DE LA CUENTA",
                DescripcionCuentaApunteContrario = "DESCRIPCION DE LA CUENTA 2",
                TipoImporte = TipoImporte.Haber,
                ReferenciaDocumento = "2017/1730",
                DescripcionApunte = "Cobro Fra: 2017/1730",
                Importe = 1000
            };

            var expectedResults = new List<string>() {
                "50000120170101057000000    DESCRIPCION DE LA CUENTA      H2017/1730 ICobro Fra: 2017/1730          +0000001000.00                                                                                                                                         NN                                                                                                                                                                                                                                                                EN",
                "50000120170101057200000    DESCRIPCION DE LA CUENTA 2    D2017/1730 UCobro Fra: 2017/1730          +0000001000.00                                                                                                                                         NN                                                                                                                                                                                                                                                                EN"
            };

            var exporter = new A3Exporter();
            var results = exporter.ExportarApunteSinIVA(apunteSinIVA);

            results.Count.Should().Be(expectedResults.Count);
            for (var i = 0; i < expectedResults.Count; i++)
            {
                results[i].Should().BeEquivalentTo(expectedResults[i]);
            }


        }


        [Fact]
        public void A3Exporter_VariosApuntes()
        {

            var apunteSinIVA = new ApunteSinIVA
            {
                CodigoEmpresa = 1,
                Fecha = new DateTime(2017, 1, 1),
                Cuenta = "57000000",
                CuentaApunteContrario = "57200000",
                DescripcionCuenta = "DESCRIPCION DE LA CUENTA",
                DescripcionCuentaApunteContrario = "DESCRIPCION DE LA CUENTA 2",
                TipoImporte = TipoImporte.Haber,
                ReferenciaDocumento = "2017/1730",
                DescripcionApunte = "Cobro Fra: 2017/1730",
                Importe = 1000
            };

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

            var expectedResults = new List<string>() {
                "50000120170101057000000    DESCRIPCION DE LA CUENTA      H2017/1730 ICobro Fra: 2017/1730          +0000001000.00                                                                                                                                         NN                                                                                                                                                                                                                                                                EN",
                "50000120170101057200000    DESCRIPCION DE LA CUENTA 2    D2017/1730 UCobro Fra: 2017/1730          +0000001000.00                                                                                                                                         NN                                                                                                                                                                                                                                                                EN",
                "50013520170101C430010010000DESCRIPCION CUENTA PROVEED    N+0000000000.00     B12x52671       Direaccion test 132, plaza 123           MUNIC               32619Ourense           988888888       988777777                                                                                                                                                                                                                                                                                                                  EN"
            };

            var exporter = new A3Exporter();
            var apuntes = new List<A3ExportableModel> {
                apunteSinIVA,
                cuentaProveedor
            };

            var results = exporter.ExportarEntidadesA3(apuntes);

            results.Count.Should().Be(expectedResults.Count);
            for (var i = 0; i < expectedResults.Count; i++)
            {
                results[i].Should().BeEquivalentTo(expectedResults[i]);
            }


        }


    }
}
