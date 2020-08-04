using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamataCalculator.Models
{
    public class SamataPostData
    {
        public string Category { get; set; } = "";
        public string JobType { get; set; } = "";
        public string JobName { get; set; } = "";
        public string Quantity { get; set; } = "";
        public string Meters { get; set; } = "";
        public string Price { get; set; } = "";
    }
}
