using wooliesx.model.models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace wooliesx.service.services
{
    /// <summary>
    /// Get User 
    /// </summary>
    public class Exercise3Service : IExercise3Service
    {
        /// <summary>
        /// Returns user response
        /// </summary>
        private readonly HttpClient _httpClient;

        public Exercise3Service(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<decimal> TrolleyTotal(Request postRequest)
        {
            const string trolleyCalculatorApiUrl = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/trolleyCalculator";
            return await ResourceLookup<decimal>(trolleyCalculatorApiUrl, postRequest);
        }
        /// <summary>
        /// Lookup resource api to servive http request
        /// </summary>
        private async Task<decimal> ResourceLookup<T>(string resourceEndpoint, Request postRequest)
        {
            const string token = "0ff1271e-5ac4-487f-bb48-37a0aaee81da";

            var requestObject = JsonConvert.SerializeObject(postRequest, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var response = await _httpClient.PostAsync($"{resourceEndpoint}?token={token}", new StringContent(requestObject, Encoding.UTF8, "application/json"));
            var readResponse = await response.Content.ReadAsStringAsync();

            if (decimal.TryParse(readResponse, out decimal temp))
            {
                return temp;
            }

            return 0M;
        }
    }
}
