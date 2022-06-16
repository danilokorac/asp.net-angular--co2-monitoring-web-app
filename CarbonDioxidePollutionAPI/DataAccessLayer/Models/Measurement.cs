using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Measurement
    {
        public int MeasurementID { get; set; }
        public Decimal MeasurementValue { get; set; }
        public DateTime MeasurementDate { get; set; }
        public int LocationID { get; set; }
        public int UserID { get; set; }
    }
}
