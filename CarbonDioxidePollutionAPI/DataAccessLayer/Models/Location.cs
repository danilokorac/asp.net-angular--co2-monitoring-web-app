using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
