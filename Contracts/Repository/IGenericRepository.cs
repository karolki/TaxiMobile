using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxiMobile.Contracts.Repository
{
    public interface IGenericRepository
    {
            Task<T> GetAsync<T>(string uri);

            Task<T> PostAsync<T>(string uri, T data);

            Task<TR> PostAsync<T, TR>(string uri, T data);

            Task<T> PutAsync<T>(string uri, T data);

            Task DeleteAsync(string uri);
    }
}
