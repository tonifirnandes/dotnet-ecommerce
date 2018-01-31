using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Qmall.Repositories;
using Qmall.Controllers;
using Qmall.Areas.Faq.Models;
using Qmall.Services.RestApi;

namespace Qmall.Areas.Faq.Controllers
{
    [Area("Faq")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string resultContent;

            HttpResponseMessage httpResponseMessage;
            FaqModel faqModel;

            httpResponseMessage = await HttpClientRequest.GetAsync(ApiEndpoints.Faq);
            resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            faqModel = JsonConvert.DeserializeObject<FaqModel>(resultContent);

            return View(faqModel);
        }
    }
}