using FluentAssertions;
using IntNovAction.Utils.A3Exporter.A3Models;
using IntNovAction.Utils.A3Exporter.Helpers;
using System;
using Xunit;

namespace IntNovAction.Utils.A3Exporter.Tests
{
    public class FixedWriterTests
    {
        [Fact]
        public void CheckWriter_CabeceraFactura()
        {
            var cabeceraFactura = new CabeceraFactura
            {
                CodigoEmpresa = 5,
                Fecha = new DateTime(2009, 4, 26),
                Cuenta = "213",                
                DescripcionCuenta = "Desc cuenta",
                DescripcionApunte = "Desc apunte",                                
                NumeroFactura = "2015-01",
                TipoFactura = TipoFactura.Compras,
                Importe = -125.34M,
                NIF = "50739013R"
            };  

            var expectedResult = "400005200904261213000000000Desc cuenta                   22015-01   IDesc apunte                   -0000000125.34                                                              50739013R     ";
            var strResult = FixedLengthWriter.WriteLine(cabeceraFactura);

            strResult.Should().BeEquivalentTo(expectedResult);
            
        }

        
    }
}
