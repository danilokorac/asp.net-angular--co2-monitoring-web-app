using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserRepository
{
    public interface IUserRepository
    {
        public User GetUser(int uid);
        public User GetUserByEmail(string email);
        public User GetUserByUsername(string username);
        public User GetUserByUsernameAndPassword(string username, string password);
        public int InsertUser(User user);
    }
}
