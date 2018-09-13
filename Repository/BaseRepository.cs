using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TaxiMobile.Repositories
{
    public class BaseRepository
    {
        protected readonly static string _serviceUrl = "http://10.0.3.2/TaxiService/TaxiService.svc/";

        protected HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        protected async Task<T> GetAsync<T>(string url)
            where T : new()
        {
            HttpClient httpClient = CreateHttpClient();
            T result;

            try
            {
                var response = await httpClient.GetStringAsync(url);
                result = await Task.Run(() => JsonConvert.DeserializeObject<T>(response));


            }
            catch
            {
                result = new T();
            }

            return result;
        }

        protected async Task<int> AddAsync(string url, object content)
        {
            HttpClient httpClient = CreateHttpClient();

            try
            {

                var stringContent = await Task.Run(() => new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));

                var response = await httpClient.PostAsync(url, stringContent);

            }
            catch
            {
                return -1;
            }

            return 1;
        }

        public async Task<T> PostRespose<T>(FormUrlEncodedContent content, string url) where T : new()
        {
            HttpClient httpClient = CreateHttpClient();
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            var response = await httpClient.PostAsync(url, content);
            var json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

    }
}

