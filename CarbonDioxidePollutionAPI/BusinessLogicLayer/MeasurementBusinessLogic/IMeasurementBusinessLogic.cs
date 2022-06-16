using BusinessLogicLayer.DTO;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MeasurementBusinessLogic
{
    public interface IMeasurementBusinessLogic
    {
        public bool InsertMeasurement(NewMeasurementDTO newMeasurement,int uid);
        public List<MeasurementDetailsDTO> GetByCountry(string countryName);
        public List<MeasurementDetailsDTO> GetByCity(string cityName);
        public List<MeasurementDetailsDTO> GetByMeasurement(string order);
        public List<MeasurementDetailsDTO> GetByDate(string order);
        public List<MeasurementDetailsDTO> GetByUserID(int uid);
        public StatisticDTO<CityAveragePollutionDTO> GetByCountryBetweenDates(DateTime startDate, DateTime endDate,string country);
        public StatisticDTO<MeasurementDetailsDTO> GetByCityBetweenDates(DateTime startDate, DateTime endDate, string city);
    }
}
