using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Contracts.Repository;
using TaxiMobile.Model;
using TaxiMobile.Repositories;

namespace TaxiMobile.Repositories
{
    public class TaxiRepository : BaseRepository, ITaxiRepository
    {
        private static readonly string _taxiUrl = "service/taxi";

        private static readonly string _taxiListUrl = "service/taxi/list";

        private static readonly string _taxiByRangeUrl = "service/taxi/list/range";

        public async Task<Taxi> GetTaxiDetails(int taxId)
        {
            var client = new RestClient(_serviceUrl);
            var request = new RestRequest(_taxiUrl, Method.POST);
            request.AddBody(taxId);
            request.AddHeader("Accept", "application/json");
            var response = await client.Execute<Taxi>(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Taxi>> GetTaxiList()
        {
            var client = new RestClient(_serviceUrl);
            var request = new RestRequest(_taxiListUrl, Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await client.Execute<List<Taxi>>(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }
     
    }
}
