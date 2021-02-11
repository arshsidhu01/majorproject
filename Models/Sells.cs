using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace majorproject.Models
{
    public class Sells
    {

        public int id { get; set; }

        public int Productsid { get; set; }
        public Products Products { get; set; }
        public int Customersid { get; set; }
        public Customers Customers { get; set; }

        public int Locationid { get; set; }
        public Location Location { get; set; }

        public int StaffsId { get; set; }
        public Staffs Staffs { get; set; }
    }
}
