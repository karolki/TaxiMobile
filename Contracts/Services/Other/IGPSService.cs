using System;
using System.Collections.Generic;
using System.Text;
using TaxiMobile.Model;

namespace TaxiMobile.Contracts.Services.Other
{
    public interface IGPSService
    {
        void GetUserLocation(Driver driver);
    }
}
