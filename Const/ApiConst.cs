using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiMobile.Const
{
    public static class ApiConst
    {

      //  private static readonly string _searchBySurnameUrl = "driver/search/surname";

       // private static readonly string _searchByIdUrl = "driver/search/url";

      //  private static readonly string _registerUrl = "driver/register";

        public const string BaseApiUrl = "http://10.0.3.2/TaxiService/TaxiService.svc/";
        public const string DriverLogin = "driver/login";
        public const string DriverRegister = "driver/register";
        public const string DriverLocate = "driver/locate";
        public const string DriverGetList = "driver/getlist";
        public const string DriverAddOpinion = "driver/addopinion";
    }
}
