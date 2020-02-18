using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NosebleedTrackerAlpha.Models
{
    public class Bleed
    {
        public int BleedId { get; set; }
        public int Severity { get; set; }
        public string Comment { get; set; }
        public DateTime? BleedDate { get; set; }

        public int Duration { get; set; }
    }
}
