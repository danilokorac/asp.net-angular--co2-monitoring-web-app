using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UserBusinessLogic
{
    public interface IMeasurementBusinessLayer
    {
        public User LogIn(User user);
        public bool InsertUser(User user);
    }
}
