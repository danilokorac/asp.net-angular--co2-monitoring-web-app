using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LocationRepository
{
    public class LocationRepository : ILocationRepository
    {
        public Location GetLocation(int measurementID)
        {
            Location location = new Location();

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Locations WHERE LocationID='{0}'", measurementID);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    location.LocationID = dr.GetInt32(0);
                    location.Country = dr.GetString(1);
                    location.City = dr.GetString(2);
                }


                return location;
            }
        }

        public int InsertLocation(Location location)
        {
            int id;
            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                string commandText = string.Format("INSERT INTO Locations VALUES( '{0}', '{1}');SELECT CAST(scope_identity() AS int)", location.Country, location.City);
                SqlCommand com = new SqlCommand(commandText, con);
                con.Open();
                id=(int)com.ExecuteScalar();
            }
            return id;
        }
    }
}
