using BusinessLogicLayer.DTO;
using DataAccessLayer.LocationRepository;
using DataAccessLayer.MeasurementRepository;
using DataAccessLayer.Models;
using DataAccessLayer.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MeasurementBusinessLogic
{
    public class MeasurementBusinessLayer : IMeasurementBusinessLogic
    {
        private IMeasurementRepository measurementRepository;
        private IUserRepository userRepository;
        private ILocationRepository locationRepository;
        
        public MeasurementBusinessLayer(IMeasurementRepository _measurementRepository, 
            IUserRepository _userRepository
            ,ILocationRepository _locationRepository)
        {
            measurementRepository = _measurementRepository;
            userRepository = _userRepository;
            locationRepository = _locationRepository;
        }
        public List<MeasurementDetailsDTO> GetByCity(string cityName)
        {
            List<Measurement> measurements = measurementRepository.GetByCity(cityName);

            return GetData(measurements);
        }

        public List<MeasurementDetailsDTO> GetByCountry(string countryName)
        {
            List<Measurement> measurements = measurementRepository.GetByCountry(countryName);
            return GetData(measurements);
        }

        public List<MeasurementDetailsDTO> GetByDate(string order)
        {
            List <Measurement> measurements = measurementRepository.GetByDate(order);
            return GetData(measurements);
        }

        public List<MeasurementDetailsDTO> GetByUserID(int uid)
        {
            List<Measurement> measurements=measurementRepository.GetByUserID(uid);
            return GetData(measurements);
        }

        public List<MeasurementDetailsDTO> GetByMeasurement(string order)
        {
            List<Measurement> measurements=measurementRepository.GetByMeasurement(order);
            return GetData(measurements); ;
        }



        public List<MeasurementDetailsDTO> GetData(List<Measurement> measurements)
        {
            List<MeasurementDetailsDTO> measurementsDetails = new List<MeasurementDetailsDTO>();

            foreach (Measurement measurement in measurements)
            {
                MeasurementDetailsDTO measurementDetailsDTO = new MeasurementDetailsDTO();
                measurementDetailsDTO.MeasurementID = measurement.MeasurementID;
                measurementDetailsDTO.MeasurementDate = measurement.MeasurementDate;
                measurementDetailsDTO.MeasurementValue = measurement.MeasurementValue;

                Location location = locationRepository.GetLocation(measurement.LocationID);
                measurementDetailsDTO.Country = location.Country;
                measurementDetailsDTO.City = location.City;

                User user = userRepository.GetUser(measurement.UserID);
                measurementDetailsDTO.Username = user.Username;

                measurementsDetails.Add(measurementDetailsDTO);

            }
            return measurementsDetails;
        }

        public bool InsertMeasurement(NewMeasurementDTO newMeasurement, int uid)
        {
            Measurement measurement = new Measurement();
            measurement.UserID = uid;
            measurement.MeasurementDate = newMeasurement.MeasurementDate;
            measurement.MeasurementValue = newMeasurement.MeasurementValue;

            Location location = new Location();
            location.City = newMeasurement.City;
            location.Country = newMeasurement.Country;

            int newInsertedLocationID=locationRepository.InsertLocation(location);
            measurement.LocationID = newInsertedLocationID;

            if (measurementRepository.InsertMeasurement(measurement) > 0)
                return true;
            else
                return false;
        }

        public StatisticDTO<CityAveragePollutionDTO> GetByCountryBetweenDates(DateTime startDate, DateTime endDate, string country)
        {
            List<Measurement> measurements = measurementRepository.GetByBetweenDates(startDate, endDate, country,true);
            List<MeasurementDetailsDTO> measurementsComplete = GetData(measurements);

            if (measurementsComplete.Count == 0)
                return null;

            List<CityAveragePollutionDTO> capdto = measurementsComplete.GroupBy(measurement=> 
            new { measurement.City }).
            Select(measurement=> new CityAveragePollutionDTO
            {
                City = measurement.Key.City,
                MeasurementValue = (int)measurement.Average(i=>i.MeasurementValue)

            }).ToList();

            int maxPollutionValue = capdto.Max(measurement => measurement.MeasurementValue);
            List<CityAveragePollutionDTO> maxPollution = capdto.Where(measurement => measurement.MeasurementValue == maxPollutionValue).ToList();
            int minPollutionValue = capdto.Min(measurement => measurement.MeasurementValue);
            List<CityAveragePollutionDTO> minPollution = capdto.Where(measurement => measurement.MeasurementValue == minPollutionValue).ToList();

            int averagePollution = (int)capdto.Average(measurement => measurement.MeasurementValue);
            StatisticDTO<CityAveragePollutionDTO> statistic = new StatisticDTO<CityAveragePollutionDTO>();
            statistic.values = capdto;
            statistic.max = maxPollution;
            statistic.min = minPollution;
            statistic.average = averagePollution;
            return statistic;
        }

        public StatisticDTO<MeasurementDetailsDTO> GetByCityBetweenDates(DateTime startDate, DateTime endDate, string city)
        {
            List<Measurement> measurements = measurementRepository.GetByBetweenDates(startDate, endDate, city, false);
            List<MeasurementDetailsDTO> measurementsComplete = GetData(measurements);
            if (measurementsComplete.Count == 0)
                return null;
            int maxPollutionValue = (int)measurementsComplete.Max(measurement => measurement.MeasurementValue);
            List<MeasurementDetailsDTO> maxPollution = measurementsComplete.Where(measurement => measurement.MeasurementValue == maxPollutionValue).ToList();

            int minPollutionValue = (int)measurementsComplete.Min(measurement => measurement.MeasurementValue);
            List<MeasurementDetailsDTO> minPollution = measurementsComplete.Where(measurement => measurement.MeasurementValue == minPollutionValue).ToList();

            int averagePollution = (int)measurementsComplete.Average(measurement => measurement.MeasurementValue);
            StatisticDTO<MeasurementDetailsDTO> statistic = new StatisticDTO<MeasurementDetailsDTO>();

            statistic.values = measurementsComplete;
            statistic.max = maxPollution;
            statistic.min = minPollution;
            statistic.average = averagePollution;
            return statistic;
        }
    }
}
