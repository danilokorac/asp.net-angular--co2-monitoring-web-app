using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LocationRepository
{
    public interface ILocationRepository
    {
        public int InsertLocation(Location location);

        public Location GetLocation(int measurementID);

    }
}
