using DataAccessLayer.Models;
using DataAccessLayer.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UserBusinessLogic
{
    public class UserBusinessLogic : IMeasurementBusinessLayer
    {
        public IUserRepository userRepository;
        public UserBusinessLogic(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public User LogIn(User user)
        {
            return userRepository.GetUserByUsernameAndPassword(user.Username,user.Password);
        }

        public bool InsertUser(User user)
        {
            User userEmail = userRepository.GetUserByEmail(user.Email);
            User userUsername = userRepository.GetUserByUsername(user.Username);

            if (userEmail != null || userUsername != null)
                return false;

            if (this.userRepository.InsertUser(user) > 0)
                return true;
            else
                return false;
        }

    }
}
