using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Contracts.Repository;
using TaxiMobile.Model;

namespace TaxiMobile.Repository
{
    public class MockDriverRepository : IDriverRepository
    {
        List<Driver> _list = new List<Driver>()
        {
            new Driver()
            {
                Drv_Name="Karol",
                Drv_Surname="Kiwała",
                Drv_Identity="kk",
                Drv_Password="haslo",
                Drv_Phone="123 123 123"
                , Drv_Latitude=65.96M,
                Drv_Longitude=67.96M,
                Drv_Timing=DateTime.Now.AddMinutes(-20)
            },
                        new Driver()
            {
                Drv_Name="Jan",
                Drv_Surname="Kowalski",
                Drv_Identity="jk",
                Drv_Password="haslo",
                Drv_Phone="123 123 333"
                , Drv_Latitude=69.96M,
                Drv_Longitude=69.96M,
                Drv_Timing=DateTime.Now.AddMinutes(-10)
            },
            new Driver()
            {
                Drv_Name="Marian",
                Drv_Surname="Kowalski",
                Drv_Identity="mk",
                Drv_Password="haslo",
                Drv_Phone="123 212 333"
                , Drv_Latitude=65.96M,
                Drv_Longitude=69.36M
                ,Drv_Timing=DateTime.Now.AddMinutes(-2)
            }
        };

        public List<Driver> list => _list;

        public bool AddOpinion(Opinion opinion)
        {
         
                foreach (var driver in list)
                {
                    if (opinion.Driver.Drv_Identity == driver.Drv_Identity)
                    {
                        driver.OpinionList.Add(opinion);
                        return true;
                    }
                }
                return false; 
        }

        public List<Driver> GetActiveDrivers()
        {

                List<Driver> temp = new List<Driver>();
                foreach (var driver in list)
                {
                    if (driver.Drv_Timing > DateTime.Now.AddMinutes(-30))
                    {
                        temp.Add(driver);
                    }
                }
                return temp;
            
        }

        public bool Locate(string ident, decimal lat, decimal lng)
        {


                foreach (var driver in _list)
                {
                    if (ident == driver.Drv_Identity)
                    {
                        driver.Drv_Latitude = lat;
                        driver.Drv_Longitude = lng;
                        driver.Drv_Timing = DateTime.Now;
                         return true;
                    }
                }
                return false;

        }

        public Driver Login(string driverId, string password)
        {


                foreach (var driver in _list)
                {
                    if (driverId == driver.Drv_Identity && password == driver.Drv_Password)
                    {
                        return driver;;
                    }
                }
                return null; 
        }

        public bool RegisterDriver(Driver Driver, string password)
        { 

                Driver.Drv_Password = password;
                _list.Add(Driver);
                return true;
        }
    }
}
