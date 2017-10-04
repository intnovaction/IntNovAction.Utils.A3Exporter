﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    /// <summary>
    /// Tipos de importe
    /// </summary>
    public enum TipoImporte
    {
        [Description("D")]
        Debe = 1,
        [Description("H")]
        Haber = 2
    }
}
