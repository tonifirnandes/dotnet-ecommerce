using Newtonsoft.Json;
using Qmall.Services.RestApi;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Qmall.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public async Task<BrandsModel> GetAsync()
        {
            string resultContent;
            HttpResponseMessage httpResponseMessage;
            BrandsModel brandsModel;

            httpResponseMessage = await HttpClientRequest.GetAsync(ApiEndpoints.AllBrands);
            resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            brandsModel = JsonConvert.DeserializeObject<BrandsModel>(resultContent);
            brandsModel.data.Add(new ObjectBrands {
                productBrandDescription = "ALL BRANDS"
            });

            return brandsModel;
        }
    }
}
