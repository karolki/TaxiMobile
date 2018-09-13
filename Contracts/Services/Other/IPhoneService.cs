using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiMobile.Contracts.Services.Other
{
    public interface IPhoneService
    {
        void MakePhoneCall(string number);
    }
}
