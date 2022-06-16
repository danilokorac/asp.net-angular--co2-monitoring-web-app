using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MeasurementRepository
{
    public class MeasurementRepository : IMeasurementRepository
    {
        public List<Measurement> GetByBetweenDates(DateTime startDate, DateTime endDate, string region, bool isCountry )
        {
            List<Measurement> measurementsBetweenDates = new List<Measurement>();
            string query = "";
            if(isCountry)
                query= string.Format("SELECT * FROM Measurements INNER JOIN Locations ON Measurements.LocationID = Locations.LocationID  WHERE Locations.Country='{0}' AND MeasurementDate BETWEEN '{1}' AND '{2}'", region, startDate.ToString("MM/dd/yyyy"), endDate.ToString("MM/dd/yyyy"));
            else
                query= string.Format("SELECT * FROM Measurements INNER JOIN Locations ON Measurements.LocationID = Locations.LocationID  WHERE Locations.City='{0}' AND MeasurementDate BETWEEN '{1}' AND '{2}'", region, startDate.ToString("MM/dd/yyyy"), endDate.ToString("MM/dd/yyyy"));

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Measurement measurement = new Measurement();
                    measurement.MeasurementID = dr.GetInt32(0);
                    measurement.MeasurementValue = dr.GetDecimal(1);
                    measurement.MeasurementDate = dr.GetDateTime(2);
                    measurement.LocationID = dr.GetInt32(3);
                    measurement.UserID = dr.GetInt32(4);
                    measurementsBetweenDates.Add(measurement);
                }


                return measurementsBetweenDates;
            }
        }

        public List<Measurement> GetByCity(string cityName)
        {
            List<Measurement> measurementsByCity = new List<Measurement>();

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Measurements INNER JOIN Locations ON Measurements.LocationID = Locations.LocationID  WHERE Locations.City='{0}'", cityName);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Measurement measurement = new Measurement();
                      measurement.MeasurementID = dr.GetInt32(0);
                      measurement.MeasurementValue = dr.GetDecimal(1);
                      measurement.MeasurementDate = dr.GetDateTime(2);
                      measurement.LocationID = dr.GetInt32(3);
                    measurement.UserID = dr.GetInt32(4);
                    measurementsByCity.Add(measurement);
                }


                return measurementsByCity;
            }
        }

        public List<Measurement> GetByCountry(string countryName)
        {
            List<Measurement> measurementsByCountry = new List<Measurement>();

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Measurements INNER JOIN Locations ON Measurements.LocationID = Locations.LocationID  WHERE Locations.Country='{0}'", countryName);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Measurement measurement = new Measurement();
                    measurement.MeasurementID = dr.GetInt32(0);
                    measurement.MeasurementValue = dr.GetDecimal(1);
                    measurement.MeasurementDate = dr.GetDateTime(2);
                    measurement.LocationID = dr.GetInt32(3);
                    measurement.UserID = dr.GetInt32(4);
                    measurementsByCountry.Add(measurement);
                }


                return measurementsByCountry;
            }
        }

        public List<Measurement> GetByDate(string order)
        {


            List<Measurement> measurementsByDateNewest= new List<Measurement>();

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                string searchOrder = "";
                if (order == "oldest")
                    searchOrder = "ASC";
                else if (order == "newest")
                    searchOrder = "DESC";

                com.CommandText = string.Format("SELECT * FROM Measurements ORDER BY MeasurementDate {0}", searchOrder);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Measurement measurement = new Measurement();
                    measurement.MeasurementID = dr.GetInt32(0);
                    measurement.MeasurementValue = dr.GetDecimal(1);
                    measurement.MeasurementDate = dr.GetDateTime(2);
                    measurement.LocationID = dr.GetInt32(3);
                    measurement.UserID = dr.GetInt32(4);
                    measurementsByDateNewest.Add(measurement);
                }


                return measurementsByDateNewest;
            }
        }

        public List<Measurement> GetByDateOldest()
        {
            List<Measurement> measurementsByDateOldest = new List<Measurement>();

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Measurements ORDER BY MeasurementDate ASC");

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Measurement measurement = new Measurement();
                    measurement.MeasurementID = dr.GetInt32(0);
                    measurement.MeasurementValue = dr.GetDecimal(1);
                    measurement.MeasurementDate = dr.GetDateTime(2);
                    measurement.LocationID = dr.GetInt32(3);
                    measurement.UserID = dr.GetInt32(4);
                    measurementsByDateOldest.Add(measurement);
                }


                return measurementsByDateOldest;
            }
        }

        public List<Measurement> GetByMeasurement(string order)
        {
            List<Measurement> measurementsByValueASC = new List<Measurement>();

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                string searchOrder = "";
                if (order == "lowest")
                    searchOrder = "ASC";
                else if (order == "highest")
                    searchOrder = "DESC"; //asc

                com.CommandText = string.Format("SELECT * FROM Measurements ORDER BY MeasurementValue {0}", searchOrder);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Measurement measurement = new Measurement();
                    measurement.MeasurementID = dr.GetInt32(0);
                    measurement.MeasurementValue = dr.GetDecimal(1);
                    measurement.MeasurementDate = dr.GetDateTime(2);
                    measurement.LocationID = dr.GetInt32(3);
                    measurement.UserID = dr.GetInt32(4);
                    measurementsByValueASC.Add(measurement);
                }


                return measurementsByValueASC;
            }
        }



        public List<Measurement> GetByUserID(int uid)
        {
            List<Measurement> measurementsByValueDESC = new List<Measurement>();

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Measurements WHERE UserID='{0}'", uid);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Measurement measurement = new Measurement();
                    measurement.MeasurementID = dr.GetInt32(0);
                    measurement.MeasurementValue = dr.GetDecimal(1);
                    measurement.MeasurementDate = dr.GetDateTime(2);
                    measurement.LocationID = dr.GetInt32(3);
                    measurement.UserID = dr.GetInt32(4);
                    measurementsByValueDESC.Add(measurement);
                }


                return measurementsByValueDESC;
            }
        }


        public int InsertMeasurement(Measurement measurement)
        {
            int result;
            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                string commandText = string.Format("INSERT INTO Measurements VALUES( '{0}', '{1}', '{2}', '{3}')", measurement.MeasurementValue, measurement.MeasurementDate.ToString("MM/dd/yyyy"), measurement.LocationID,measurement.UserID);
                SqlCommand com = new SqlCommand(commandText, con);
                con.Open();
                result = com.ExecuteNonQuery();
            }
            return result;
        }
    }
}
