using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using TaxiMobile.Contracts.Services.Other;

namespace TaxiMobile.Services.Other
{
    public class PhoneService :IPhoneService
    {
        public void MakePhoneCall(string number)
        {
            CrossMessaging.Current.PhoneDialer.MakePhoneCall(number);
        }
    }
}
