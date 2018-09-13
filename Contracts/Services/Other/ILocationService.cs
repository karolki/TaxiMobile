using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Model;

namespace TaxiMobile.Contracts.Services
{
    public interface ILocationService
    {
        Task GetUserLocation(Driver driver);
    }
}
