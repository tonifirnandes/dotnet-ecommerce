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
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<CategoriesModel> GetAsync()
        {
            string resultContent;
            HttpResponseMessage httpResponseMessage;
            CategoriesModel categoriesModel;

            httpResponseMessage = await HttpClientRequest.GetAsync(ApiEndpoints.AllCategories);
            resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            categoriesModel = JsonConvert.DeserializeObject<CategoriesModel>(resultContent);

            return categoriesModel;
        }
    }
}
