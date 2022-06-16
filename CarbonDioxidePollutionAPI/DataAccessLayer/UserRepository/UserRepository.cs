using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(int uid)
        {
            User user = new User();

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Users WHERE UserID='{0}'", uid);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    user.UserID = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.Password = dr.GetString(2);
                    user.Email = dr.GetString(3);
                }


                return user;
            }
        }

        public User GetUserByEmail(string email)
        {
            User user = null;

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Users WHERE Email='{0}'", email);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    user = new User();
                    user.UserID = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.Password = dr.GetString(2);
                    user.Email = dr.GetString(3);
                }


                return user;
            }
        }

        public User GetUserByUsername(string username)
        {
            User user = null;

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Users WHERE Username='{0}'", username);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    user = new User();
                    user.UserID = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.Password = dr.GetString(2);
                    user.Email = dr.GetString(3);
                }


                return user;
            }
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User user = null;

            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = string.Format("SELECT * FROM Users WHERE Username='{0}' AND Password='{1}'", username, password);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    user= new User();
                    user.UserID = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.Password = dr.GetString(2);
                    user.Email = dr.GetString(3);
                }


                return user;
            }
        }

        public int InsertUser(User user)
        {
            int result;
            using (SqlConnection con = new SqlConnection(Constants.Constants.connString))
            {
                string commandText = string.Format("INSERT INTO Users VALUES( '{0}', '{1}', '{2}')", user.Username, user.Password, user.Email);
                SqlCommand com = new SqlCommand(commandText, con);
                con.Open();
                result = com.ExecuteNonQuery();
            }
            return result;
        }
    }
}
