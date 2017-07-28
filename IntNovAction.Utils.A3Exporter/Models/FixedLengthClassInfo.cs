using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Models
{
    internal class FixedLengthClassInfo
    {
        public int LineLength { get; set; }

        public List<FixedLengthPropertyInfo> Properties { get; set; } = new List<FixedLengthPropertyInfo>();
    }
}
