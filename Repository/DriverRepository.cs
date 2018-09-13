using Newtonsoft.Json;
using RestSharp;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Const;
using TaxiMobile.Contracts.Repository;
using TaxiMobile.Model;
using TaxiMobile.Repositories;
using TaxiMobile.Repository;

namespace TaxiMobile.Repositories
{
    public class DriverRepository : BaseRepository, IDriverRepository
    {
        public List<Driver> list => throw new NotImplementedException();

        [DataContractAttribute]
        public class LoginBody
        {
            public LoginBody(string ident, string password)
            {
                this.ident = ident;
                this.password = password;
            }
            [DataMemberAttribute]
            public virtual string ident { get; set; }
            [DataMemberAttribute]
            public virtual string password { get; set; }
        }
        //public Driver Login(string driverIdent, string password)
        //{
        //    //try
        //    //{
        //    //    var client = new RestClient(_serviceUrl);
        //    //    var request = new RestRequest(ApiConst.DriverLogin, Method.POST);
        //    //    string ident = driverIdent;
        //    //    request.AddBody(new LoginBody(driverIdent, password));
        //    //    request.AddHeader("Accept", "application/json");
        //    //    var response = await client.Execute<Driver>(request);
        //    //    if (response.IsSuccess)
        //    //    {
        //    //        return response.Data;
        //    //    }
        //    //    else
        //    //    {
        //    //        return null;
        //    //    }
        //    //}
        //    //catch (Exception e){return null; }
        //}
        [DataContractAttribute]
        public class RegisterBody
        {
            public RegisterBody(Driver driver, string password)
            {
                this.driver = driver;
                this.password = password;
            }
            [DataMemberAttribute]
            public virtual Driver driver { get; set; }
            [DataMemberAttribute]
            public virtual string password { get; set; }
        }
        public async Task<bool> RegisterDriver(Driver driver,string password)
        {
            try
            {
                var client = new RestClient(_serviceUrl);
                var request = new RestRequest(ApiConst.DriverRegister, Method.POST);
                request.AddBody(new RegisterBody(driver, password));
                request.AddHeader("Accept", "application/json");
                
                var body = request.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault();
                var text = System.Text.Encoding.UTF8.GetString((body.Value as byte[]));
                var response = await client.Execute<bool>(request);
                if (response.IsSuccess)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            { return false; }
        }

        public async Task<List<Driver>> GetActiveDrivers()
        {
            try
            {
                var client = new RestClient(_serviceUrl);
                var request = new RestRequest(ApiConst.DriverGetList, Method.GET);
                request.AddHeader("Accept", "application/json");
                var response = await client.Execute<List<Driver>>(request);
                if (response.IsSuccess)
                {
                    return response.Data;
                }
                else
                {
                    return new List<Driver>();
                }
            }
            catch (Exception e) { return new List<Driver>(); }
        }

        public async Task<bool> AddOpinion(Opinion opinion)
        {
            var client = new RestClient(_serviceUrl);
            var request = new RestRequest(ApiConst.DriverAddOpinion, Method.POST);
            request.AddBody(opinion);
            request.AddHeader("Accept", "application/json");
            var response = await client.Execute<bool>(request);
            if (response.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [DataContractAttribute]
        public class LocateBody
        {
            public LocateBody(string ident, decimal lat, decimal lng)
            {
                this.ident = ident;
                this.lat = lat;
                this.lng = lng;
            }
            [DataMemberAttribute]
            public virtual string ident { get; set; }
            [DataMemberAttribute]
            public virtual decimal lat { get; set; }
            [DataMemberAttribute]
            public virtual decimal lng { get; set; }
        }
        public async Task<bool> Locate(string ident, decimal lat, decimal lng)
        {
            var client = new RestClient(_serviceUrl);
            var request = new RestRequest(ApiConst.DriverLocate, Method.POST);
            request.AddBody(new LocateBody(ident, lat,lng));
            request.AddHeader("Accept", "application/json");
            var response = await client.Execute<bool>(request);
            if (response.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        List<Driver> IDriverRepository.GetActiveDrivers()
        {
            throw new NotImplementedException();
        }

        bool IDriverRepository.RegisterDriver(Driver Driver, string password)
        {
            throw new NotImplementedException();
        }

        bool IDriverRepository.AddOpinion(Opinion opinion)
        {
            throw new NotImplementedException();
        }

        bool IDriverRepository.Locate(string ident, decimal lat, decimal lng)
        {
            throw new NotImplementedException();
        }

        public Driver Login(string driverId, string password)
        {
            throw new NotImplementedException();
        }
    }
}
