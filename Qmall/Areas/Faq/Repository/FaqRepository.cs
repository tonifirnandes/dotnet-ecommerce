using Newtonsoft.Json;
using Qmall.Services.RestApi;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Qmall.Repositories;
using Qmall.Areas.Faq.Models;

namespace Qmall.Areas.Faq.Repository
{
    public class FaqRepository : IFaqRepository
    {       
        public async Task<FaqModel> GetAsync()
        {
            HttpResponseMessage httpResponseMessage = await HttpClientRequest.GetAsync(ApiEndpoints.Faq);                      

            return JsonConvert.DeserializeObject<FaqModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }
    }
}
