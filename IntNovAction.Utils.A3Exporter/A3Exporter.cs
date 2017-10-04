using IntNovAction.Utils.A3Exporter.A3Models;
using IntNovAction.Utils.A3Exporter.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<string> ExportarEntidadesA3(List<A3ExportableModel> entidades)
        {
            var result = new List<string>();

            foreach (var entidad in entidades)
            {
                result.AddRange(ExportarEntidadA3(entidad));
            }

            return result;
        }

        /// <summary>
        /// Exporta una factura con sus líneas a un conjunto de líneas de texto para el fichero de A3
        /// </summary>
        /// <param name="factura">Datos de la factura</param>
        /// <returns>líneas para incluir en el fichero de A3</returns>
        public List<string> ExportarFactura(Factura factura)
        {
            return ExportarEntidadA3(factura);
        }

        /// <summary>
        /// Exporta los datos de una cuenta de un proveedor a una línea de texto para el fichero de A3
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public string ExportarCuentaProveedor(CuentaProveedor cuenta)
        {
            return ExportarEntidadA3(cuenta).FirstOrDefault();
        }

        /// <summary>
        /// Exporta los datos de un apunte sin IVA líneas de texto para el fichero de A3
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public List<string> ExportarApunteSinIVA(ApunteSinIVA apunte)
        {            
            return ExportarEntidadA3(apunte);
        }

        private List<string> ExportarEntidadA3(A3ExportableModel entidadA3Exportable)
        {
            var result = new List<string>();

            var lineas = entidadA3Exportable.ObtenerLineas();
            foreach (var linea in lineas)
            {
                result.Add(_writer.WriteLine(linea));
            }

            return result;

        }
    }
}
