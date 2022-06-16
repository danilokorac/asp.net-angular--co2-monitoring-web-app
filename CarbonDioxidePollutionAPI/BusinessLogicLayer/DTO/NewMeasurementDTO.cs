using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class NewMeasurementDTO
    {
        public Decimal MeasurementValue { get; set; }
        public DateTime MeasurementDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
