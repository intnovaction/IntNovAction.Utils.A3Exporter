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
            var factura = new Factura("2017/1002")
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 4, 26),
                Cuenta = "430010370000",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoFactura = TipoFactura.Ventas,
                DescripcionApunte = "Factura: 2017/1002",
                Importe = 4867.23M
            };

            var linea1 = new LineaFactura
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 4, 26),
                Cuenta = "705100020000",
                DescripcionCuenta = "SERVICIOS JURIDICOS TEST",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "(HN)Factura: 2017/1002",
                BaseImponible = 4022.5M,
                PorcentajeIVA = 21,
                TipoImpreso = TipoImpreso.Impreso_347
            };

            factura.AddLineaFactura(linea1);

            var linea2 = new LineaFactura
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 4, 26),
                Cuenta = "566010370000",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "Suplidos de: 2017/1002",
                BaseImponible = 650,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea2);

            var linea3 = new LineaFactura
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 4, 26),
                Cuenta = "561010370000",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Abono,
                DescripcionApunte = "Provisiones de: 2017/1002",
                BaseImponible = 1763.87M,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea3);

            var linea4 = new LineaFactura
            {
                CodigoEmpresa = 135,
                Fecha = new DateTime(2017, 4, 26),
                Cuenta = "430010370000",
                DescripcionCuenta = "Test Nombre cuenta",
                TipoImporte = TipoImporteFactura.Cargo,
                DescripcionApunte = "Regularizacion de: 2017/1002",
                BaseImponible = 1113.87M,
                TipoImpreso = TipoImpreso.Impreso_110_AgrariosDinerarias
            };
            factura.AddLineaFactura(linea4);

            var expectedResults = new List<string>() {
                "300135201704261430010370000Test Nombre cuenta            12017/1002 IFactura: 2017/1002            +0000004867.23                                                                                                                                           EN",
                "300135201704269705100020000SERVICIOS JURIDICOS TEST      C2017/1002 M(HN)Factura: 2017/1002        01+0000004022.5021.00+0000000844.7300.00+0000000000.0000.00+0000000000.0001S                                                                            NEN",
                "300135201704269566010370000Test Nombre cuenta            C2017/1002 MSuplidos de: 2017/1002        01+0000000650.0000.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            NEN",
                "300135201704269561010370000Test Nombre cuenta            A2017/1002 MProvisiones de: 2017/1002     01+0000001763.8700.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            NEN",
                "300135201704269430010370000Test Nombre cuenta            C2017/1002 URegularizacion de: 2017/1002  01+0000001113.8700.00+0000000000.0000.00+0000000000.0000.00+0000000000.0007N                                                                            NEN"
            };

            var exporter = new A3Exporter();
            var results = exporter.ExportarFactura(factura);

            results.Count.Should().Be(5);
            results[0].Should().BeEquivalentTo(expectedResults[0]);
            results[1].Should().BeEquivalentTo(expectedResults[1]);
            results[2].Should().BeEquivalentTo(expectedResults[2]);
            results[3].Should().BeEquivalentTo(expectedResults[3]);
            results[4].Should().BeEquivalentTo(expectedResults[4]);

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

            var expectedResult = "30013520170101C430010010000DESCRIPCION CUENTA PROVEED    N+0000000000.00     B12x52671       Direaccion test 132, plaza 123           MUNIC               32619Ourense           988888888       988777777                                               R  EN";

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
                Fecha = new DateTime(2017,7, 19),
                Cuenta = "43037490",
                CuentaApunteContrario = "57200004",
                DescripcionCuenta = "MIGUEL ANGEL LATOS RASCOCARSA",
                DescripcionCuentaApunteContrario = "123 AACC ACCIONES Y PREFERENTE",
                TipoImporte = TipoImporte.Haber,
                ReferenciaDocumento = "2017/1730",
                DescripcionApunte = "Cobro Fra: 2017/1730",
                Importe = 7910.98M
            };

            var expectedResults = new List<string>() {
                "40000120170719043037490    MIGUEL ANGEL LATOS RASCOCARSA H2017/1730 ICobro Fra: 2017/1730          +0000007910.98                                                                                                                                          NEN",
                "40000120170719057200004    123 AACC ACCIONES Y PREFERENTED2017/1730 UCobro Fra: 2017/1730          +0000007910.98                                                                                                                                          NEN"
            };

            var exporter = new A3Exporter();
            var results = exporter.ExportarApunteSinIVA(apunteSinIVA);

            results.Count.Should().Be(2);
            results[0].Should().BeEquivalentTo(expectedResults[0]);
            results[1].Should().BeEquivalentTo(expectedResults[1]);


        }


        [Fact]
        public void A3Exporter_VariosApuntes()
        {

            var apunteSinIVA = new ApunteSinIVA
            {
                CodigoEmpresa = 1,
                Fecha = new DateTime(2017, 7, 19),
                Cuenta = "43037490",
                CuentaApunteContrario = "57200004",
                DescripcionCuenta = "MIGUEL ANGEL LATOS RASCOCARSA",
                DescripcionCuentaApunteContrario = "123 AACC ACCIONES Y PREFERENTE",
                TipoImporte = TipoImporte.Haber,
                ReferenciaDocumento = "2017/1730",
                DescripcionApunte = "Cobro Fra: 2017/1730",
                Importe = 7910.98M
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
                "40000120170719043037490    MIGUEL ANGEL LATOS RASCOCARSA H2017/1730 ICobro Fra: 2017/1730          +0000007910.98                                                                                                                                          NEN",
                "40000120170719057200004    123 AACC ACCIONES Y PREFERENTED2017/1730 UCobro Fra: 2017/1730          +0000007910.98                                                                                                                                          NEN",
                "30013520170101C430010010000DESCRIPCION CUENTA PROVEED    N+0000000000.00     B12x52671       Direaccion test 132, plaza 123           MUNIC               32619Ourense           988888888       988777777                                               R  EN"
            };

            var exporter = new A3Exporter();
            var apuntes = new List<A3ExportableModel> {
                apunteSinIVA,
                cuentaProveedor
            };

            var results = exporter.ExportarEntidadesA3(apuntes);

            results.Count.Should().Be(3);
            results[0].Should().BeEquivalentTo(expectedResults[0]);
            results[1].Should().BeEquivalentTo(expectedResults[1]);
            results[2].Should().BeEquivalentTo(expectedResults[2]);


        }


    }
}
