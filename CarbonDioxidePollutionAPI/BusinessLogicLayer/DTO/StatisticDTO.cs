using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class StatisticDTO<T>
    {
        public List<T> values { get; set; }
        public List<T> max { get; set; }
        public List<T> min { get; set; }
        public int average { get; set; }
    }
}
