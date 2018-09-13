using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Model;

namespace TaxiMobile.Contracts.Services
{
    public interface IDriverDataService
    {
        List<Driver> GetActiveDrivers();

        Driver Login(string driverId, string password);

        bool Register(Driver Driver, string password);

        bool AddOpinion(Opinion opinion);

        bool Locate(decimal lat, decimal lng);

        void Logout();

        Driver ActiveDriver { get; }
    }
}
