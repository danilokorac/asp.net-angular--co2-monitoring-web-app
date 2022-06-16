using BusinessLogicLayer.DTO;
using BusinessLogicLayer.MeasurementBusinessLogic;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarbonDioxidePollutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private IMeasurementBusinessLogic measurementBusinessLogic;
        public MeasurementController(IMeasurementBusinessLogic _measurementBusinessLogic)
        {
            measurementBusinessLogic = _measurementBusinessLogic;
        }

        [HttpPost("insertmeasurement")]
        [Authorize]
        public IActionResult InsertNewMeasurement([FromBody] NewMeasurementDTO measurement)
        {
            var claim = User.Claims.FirstOrDefault(claim => claim.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
            int id = Int32.Parse(claim.Value);

            if (measurementBusinessLogic.InsertMeasurement(measurement,id))
                return Ok(id);
            else
                return BadRequest(id);
        }

        [HttpGet("getby/date/newest")]
        public List<MeasurementDetailsDTO> GetByDateNewest()
        {
            return measurementBusinessLogic.GetByDate("newest");
        }

        [HttpGet("getby/date/oldest")]
        public List<MeasurementDetailsDTO> GetByDateOldest()
        {
            return measurementBusinessLogic.GetByDate("oldest");
        }

        [HttpGet("getby/measurement/highest")]
        public List<MeasurementDetailsDTO> GetByMeasurementHighest()
        {
            return measurementBusinessLogic.GetByMeasurement("highest");
        }
        [HttpGet("getby/measurement/lowest")]
        public List<MeasurementDetailsDTO> GetByMeasurementLowest()
        {
            return measurementBusinessLogic.GetByMeasurement("lowest");
        }
        [HttpGet("getby/country/{countryName}")]
        public List<MeasurementDetailsDTO> GetByCountry(string countryName)
        {
            return measurementBusinessLogic.GetByCountry(countryName);
        }

        [HttpGet("getby/city/{cityName}")]
        public List<MeasurementDetailsDTO> GetByCity(string cityName)
        {
            return measurementBusinessLogic.GetByCity(cityName);
        }

        [HttpGet("getby/user")]
        public List<MeasurementDetailsDTO> GetByUserID()
        {
            var claim = User.Claims.FirstOrDefault(claim => claim.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
            int id = Int32.Parse(claim.Value);
            return measurementBusinessLogic.GetByUserID(id);
        }
        //GetByBetweenDates

        [HttpGet("getby/date/{startDate}/{endDate}/country/{country}")]
        public StatisticDTO<CityAveragePollutionDTO> GetByCountryBetweenDates(DateTime startDate, DateTime endDate,string country)
        {
            return measurementBusinessLogic.GetByCountryBetweenDates(startDate, endDate, country);
        }

        [HttpGet("getby/date/{startDate}/{endDate}/city/{city}")]
        public StatisticDTO<MeasurementDetailsDTO> GetByCityBetweenDates(DateTime startDate, DateTime endDate, string city)
        {
            return measurementBusinessLogic.GetByCityBetweenDates(startDate, endDate, city);
        }

    }
}
