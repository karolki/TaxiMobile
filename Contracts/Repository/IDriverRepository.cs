using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Model;

namespace TaxiMobile.Contracts.Repository
{
    public interface IDriverRepository
    {
        List<Driver> GetActiveDrivers();

        Driver Login(string driverId, string password);

        bool RegisterDriver(Driver Driver,string password);

        bool AddOpinion(Opinion opinion);

        bool Locate(string ident, decimal lat, decimal lng);

        List<Driver> list { get; }
    }
}
