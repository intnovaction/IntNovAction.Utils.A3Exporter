using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    /// <summary>
    /// Tipo de formato para campos: si un campo no se formatea con la opción por defecto, se utiliza esta opción. Por ejemplo:
    /// - el decimal por defecto se formatea como +000000000.00, pero se puede forzar a porcentaje con formato 00.00
    /// - los enumerados por defecto se formatean en su representación como número, pero se puede forzar a que se formatee con el valor del atributo Description (EnumDesc)
    /// </summary>
    public enum FormatType
    {
        General = 0,
        Percent = 1,
        EnumDesc = 2,
    }
}
