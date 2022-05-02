using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBIApplication.Models
{
    public class PoliceModel
    {
        public int PoliceModelID { get; set; }
        public int data_year { get; set; }
        public int population { get; set; }
        public int officer_count { get; set; }
        public float officer_rate_per_1000 { get; set; }

    }
}
