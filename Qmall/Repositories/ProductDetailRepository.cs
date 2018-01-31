using Newtonsoft.Json;
using Qmall.Models;
using Qmall.Models.ProductDetail;
using Qmall.Services.RestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Qmall.Repositories
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        public async Task<ProductDetailBaseModel> GetAsyncParamDetailLogin(string parameters, string email, string customerToken)
        {
            string resultContent;
            HttpResponseMessage httpResponseMessage;
            ProductDetailBaseModel productDetailModel;

            httpResponseMessage = await HttpClientRequest.GetAsyncParam(ApiEndpoints.ProductDetail, parameters, email, customerToken);
            resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            productDetailModel = JsonConvert.DeserializeObject<ProductDetailBaseModel>(resultContent);

            return productDetailModel;
        }

        public async Task<ProductDetailViewModel> GetAsyncParam(string parameters)
        {
            string resultContent;
            HttpResponseMessage httpResponseMessage;
            ProductDetailViewModel productDetailModel;

            httpResponseMessage = await HttpClientRequest.GetAsyncParam(ApiEndpoints.ProductDetail, parameters);
            resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            productDetailModel = JsonConvert.DeserializeObject<ProductDetailViewModel>(resultContent);

            return productDetailModel;
        }
    }
}
