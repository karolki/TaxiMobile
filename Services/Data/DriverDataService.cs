using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Contracts.Repository;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Model;

namespace TaxiMobile.Services
{
    public class DriverDataService : IDriverDataService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IDriverRepository _driverRepository;
        private Driver _activeDriver;

        public Driver ActiveDriver => _activeDriver;

        public DriverDataService(IDriverRepository driverRepository, IGenericRepository genericRepository)
        {
            _driverRepository = driverRepository;
            _genericRepository = genericRepository;
        }


        public Driver Login(string driverId, string password)
        {
            _activeDriver =  _driverRepository.Login(driverId, password);
            return _activeDriver;
        }
 

        public  bool Register(Driver driver,string password)
        {
            return  _driverRepository.RegisterDriver(driver,password);
        }


        public void Logout()
        {
            _activeDriver = null;
        }

        public List<Driver> GetActiveDrivers()
        {
            return  _driverRepository.GetActiveDrivers();
        }

        public bool RegisterDriver(Driver Driver, string password)
        {
            return  _driverRepository.RegisterDriver(Driver, password);
        }

        public bool AddOpinion(Opinion opinion)
        {
            return  _driverRepository.AddOpinion(opinion);
        }

        public bool Locate(decimal lat,decimal lng)
        {
            return _driverRepository.Locate(ActiveDriver.Drv_Identity, lat,lng);
        }
    }
}
