using IntNovAction.Utils.A3Exporter.A3Models;
using IntNovAction.Utils.A3Exporter.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("IntNovAction.Utils.A3Exporter.InternalTests")]
namespace IntNovAction.Utils.A3Exporter
{
    /// <summary>
    /// Utilidad para exportar los distintos conceptos a fichero de A3
    /// </summary>
    public class A3Exporter
    {
        private FixedLengthWriter _writer;

        public A3Exporter()
        {
            this._writer = new FixedLengthWriter();
        }
        /// <summary>
        /// Exporta una factura con sus líneas a un conjunto de líneas de texto para el fichero de A3
        /// </summary>
        /// <param name="factura">Datos de la factura</param>
        /// <returns>líneas para incluir en el fichero de A3</returns>
        public List<string> ExportarFactura(Factura factura)
        {
            var result = new List<string>();

            var strFactura = _writer.WriteLine(factura);
            result.Add(strFactura);

            foreach (var lineaFactura in factura.Lineas)
            {
                var strLinea = _writer.WriteLine(lineaFactura);
                result.Add(strLinea);
            }

            return result;
        }

        /// <summary>
        /// Exporta los datos de una cuenta de un proveedor a una línea de texto para el fichero de A3
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public string ExportarCuentaProveedor(CuentaProveedor cuenta)
        {
            return _writer.WriteLine(cuenta);
        }
    }
}
