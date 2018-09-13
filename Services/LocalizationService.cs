using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiMobile.Services
{
    public class LocalizationService
    {
        public static decimal Lat { get { return 78.56M; } }
        public static decimal Lng { get { return 69.56M; } }
        public static decimal Distance(decimal lat, decimal lng)
        {
            int R = 6371; // km
            decimal x = (Lng - lng) * (decimal)Math.Cos((double)((Lat + lat) / 2));
            decimal y = (lat - Lat);
            return (decimal)Math.Sqrt((double)(x * x + y * y)) * R;
        } 
              
    
    }
}
