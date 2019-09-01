using System;
using System.Threading.Tasks;
using wooliesx.model.models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace wooliesx.service.services
{
    /// <summary>
    /// Handle sort request service
    /// </summary>
    public class Exercise2Service : IExercise2Service
    {
        private readonly HttpClient _httpClient;

        public Exercise2Service(HttpClient client)
        {
            _httpClient = client;
        }
        /// <summary>
        /// sorting products based on sort options
        /// </summary>
        public async Task<List<Product>> SortProducts(string sortOptions)
        {
            if (string.Equals(sortOptions, "Recommended", StringComparison.OrdinalIgnoreCase))
            {
                return await GetShopperHistory();
            }
            var productList = await GetProducts();
            return SortProductList(sortOptions, productList);
        }

        /// <summary>
        /// Get products from product resource
        /// </summary>
        private async Task<List<Product>> GetProducts()
        {

            const string productResourceApiUrl = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products";
            return await ResourceLookup<List<Product>>(productResourceApiUrl);

        }

        /// <summary>
        /// calling shopperHistory for sortoption recommended
        /// </summary>
        private async Task<List<Product>> GetShopperHistory()
        {

            const string productResourceApiUrl = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory";
            var customers = await ResourceLookup<List<Customer>>(productResourceApiUrl);
            var customerList = new List<Product>();
            foreach (Customer c in customers)
            {
                customerList.AddRange(c.Products);
            }
            return customerList;

        }

        /// <summary>
        /// sorting products based on sortoptions Low, High, Ascending, Descending
        /// </summary>
        private List<Product> SortProductList(string sortOptions, List<Product> productForSort)
        {
            if (string.Equals(sortOptions, "Low", StringComparison.OrdinalIgnoreCase))
            {
                var result = productForSort.OrderBy(x => x.Price).ToList();
                return result;
                //Low to High Price
            }
            else if (string.Equals(sortOptions, "High", StringComparison.OrdinalIgnoreCase))
            {
                //High to Low Price
                var result = productForSort.OrderByDescending(x => x.Price).ToList();
                return result;
            }
            else if (string.Equals(sortOptions, "Ascending", StringComparison.OrdinalIgnoreCase))
            {
                //A - Z sort on the Name
                var result = productForSort.OrderBy(x => x.Name).ToList();
                return result;
            }
            else if (string.Equals(sortOptions, "Descending", StringComparison.OrdinalIgnoreCase))
            {
                //Z - A sort on the Name
                var result = productForSort.OrderByDescending(x => x.Name).ToList();
                return result;
            }
            return productForSort;

        }

        /// <summary>
        /// Lookup resource api to servive http request
        /// </summary>
        private async Task<T> ResourceLookup<T>(string resourceEndpoint)
        {
            const string token = "0ff1271e-5ac4-487f-bb48-37a0aaee81da";
            var response = await _httpClient.GetStringAsync($"{resourceEndpoint}?token={token}");
            var productList = JsonConvert.DeserializeObject<T>(response);
            return productList;
        }
    }

}
