using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamataCalculator.Models
{
    public class JobDone
    {
        public string Category { get; set; }
        public string JobType { get; set; }
        public string JobName { get; set; }
        public int Quantity { get; set; }
        public int Meters { get; set; }
        public int Price { get; set; }
    }
}
