using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    /// <summary>
    /// Subtipos de factura de A3
    /// </summary>
    public enum SubtipoFactura
    {
        OperacionSujetaIVA = 1,
        OperacionExentaSinDeduccion = 2,
        EntregaIntracomunitaria = 3,
        EntregaIntracomunitariaSinDeduccion = 4,
        CanariasCeutaMelilla = 5,
        Exportaciones = 6,
        OtrasOperacionesNoIVA = 7,
        OtrasOperacionesDerechoDevolucion = 8,
        OtrasOperacionesDerechoDeduccion = 9
    }
}
