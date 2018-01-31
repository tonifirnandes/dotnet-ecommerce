using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Qmall.Areas.Newsletter.Models;
using Qmall.Models;
using Qmall.Repositories;
using Qmall.Services.RestApi;

namespace Qmall.Areas.Newsletter.Controllers
{
    [Area("Newsletter")]
    public class NewsletterController : Controller
    {
        private INewsletterRepository NewsletterRepository;
        const string KEYWORD_EMAIL_PARAMETER = "email";
        const string RESPONSE_HEADER_MESSAGE_STATUS = "messageStatus";

        public NewsletterController(INewsletterRepository newsletterRepository)
        {
            NewsletterRepository = newsletterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            NewsletterModel newsletterModel = await NewsletterRepository.GetAsync();
            List<ObjectNewsletter> newsletterList = new List<ObjectNewsletter>(newsletterModel.data.Capacity);
            newsletterList.AddRange(newsletterModel.data);
            return PartialView(new NewsletterViewModel(newsletterList));
        }

        [HttpPost]
        public async Task<int> SubscribeNewsletter(string email)
        {
            string resultContent = "";
            int statusCode;

            HttpResponseMessage responseMessage;
            SubscribeEmailModel subscribeEmailModel;

            if (String.IsNullOrEmpty(email))
            {
                statusCode = (int)HttpStatusCode.Forbidden;
            }
            else
            {
                var parameters = new Dictionary<string, string>
                {
                    { KEYWORD_EMAIL_PARAMETER, email }
                };
                responseMessage = await HttpClientRequest.PostAsync(ApiEndpoints.SubscribeEmail, parameters);
                resultContent = await responseMessage.Content.ReadAsStringAsync();

                subscribeEmailModel = JsonConvert.DeserializeObject<SubscribeEmailModel>(resultContent);

                if (subscribeEmailModel.code == 1001)
                {
                    statusCode = subscribeEmailModel.code;
                }
                else if (subscribeEmailModel.code == 1000)
                {
                    statusCode = subscribeEmailModel.code;
                }
                else
                {
                    statusCode = (int)HttpStatusCode.InternalServerError;
                }
            }

            return statusCode;
        }
    }
}