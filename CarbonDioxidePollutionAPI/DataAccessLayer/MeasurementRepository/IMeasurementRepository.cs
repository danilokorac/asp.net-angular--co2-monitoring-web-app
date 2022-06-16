using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MeasurementRepository
{
    public interface IMeasurementRepository
    {
        public int InsertMeasurement(Measurement measurement);
        public List<Measurement> GetByCountry(string countryName);
        public List<Measurement> GetByCity(string cityName);
        public List<Measurement> GetByMeasurement(string orders);
        public List<Measurement> GetByDate(string order);
        public List<Measurement> GetByUserID(int uid);
        public List<Measurement> GetByBetweenDates(DateTime startDate, DateTime endDate, string region, bool isCountry);
    }
}
