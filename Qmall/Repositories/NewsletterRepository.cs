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
    public class NewsletterRepository : INewsletterRepository
    {
        public async Task<NewsletterModel> GetAsync()
        {
            string resultContent;

            HttpResponseMessage httpResponseMessage;
            NewsletterModel newsletterModel;

            httpResponseMessage = await HttpClientRequest.GetAsync(ApiEndpoints.Newsletter);
            resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            newsletterModel = JsonConvert.DeserializeObject<NewsletterModel>(resultContent);

            return newsletterModel;
        }
    }
}
