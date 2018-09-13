using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Model;
using TaxiMobile.Models;

namespace TaxiMobile.Contracts.Repository
{
    public interface ITaxiRepository
    {
        Task<Taxi> GetTaxiDetails(int taxId);

        Task<List<Taxi>> GetTaxiList();


    }
}
