using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NosebleedTrackerAlpha.Models
{
    public class Report
    {
        public int? Average { get; set; }

        public long? Frequency { get; set; }

        public int? Duration { get; set; }

        public int? CustomAverage { get; set; }
        public long? CustomFrequency { get; set; }
    }
}
