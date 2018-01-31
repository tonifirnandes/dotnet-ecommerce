using Newtonsoft.Json;
using Qmall.Services.RestApi;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Qmall.Areas.SearchProducts.Models;

namespace Qmall.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<ProductsTopViewModel> GetTopViewAsync()
        {
            string resultContent;
            HttpResponseMessage httpResponseMessage;
            ProductsTopViewModel productsTopViewModel;

            httpResponseMessage = await HttpClientRequest.GetAsync(ApiEndpoints.ProductTopView);
            resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            productsTopViewModel = JsonConvert.DeserializeObject<ProductsTopViewModel>(resultContent);

            return productsTopViewModel;
        }
        public async Task<SearchProductsViewModel> SearchFilter(string parameters, string email, string customerToken)
        {
            string resultContent;
            HttpResponseMessage httpResponseMessage;
            SearchProductsViewModel searchProductsViewModel;

            httpResponseMessage = await HttpClientRequest.GetAsyncParam(ApiEndpoints.SearchFilter, parameters, email, customerToken);
            resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            searchProductsViewModel = JsonConvert.DeserializeObject<SearchProductsViewModel>(resultContent);

            return searchProductsViewModel;
        }
    }
}
