using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Helpers
{
    public class FixedLengthClassInfo
    {
        public int LineLength { get; set; }

        public List<FixedLengthPropertyInfo> Properties { get; set; } = new List<FixedLengthPropertyInfo>();
    }
}
