using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.A3Models
{
    public abstract class A3ExportableModel : A3ModelBase
    {
        internal abstract List<A3ModelBase> ObtenerLineas();
    }
}
