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
    public class TaxiDataService : ITaxiDataService
    {
        private readonly ITaxiRepository _taxiRepository;

        public TaxiDataService(ITaxiRepository taxiRepository)
        {
            _taxiRepository = taxiRepository;
        }

        public async Task<Taxi> GetTaxiDetails(int taxId)
        {
            return await _taxiRepository.GetTaxiDetails(taxId);
        }

        public async Task<List<Taxi>> GetTaxiList()
        {
            return await _taxiRepository.GetTaxiList();
        }

    }
}
