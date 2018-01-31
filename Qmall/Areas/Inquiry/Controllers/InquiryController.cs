using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Qmall.Areas.Inquiry.Models;
using Qmall.Extensions;
using Qmall.Repositories;
using Qmall.Services.RestApi;

namespace Qmall.Areas.Inquiry.Controllers
{
    [Area("Inquiry")]
    public class InquiryController : Controller
    {
        const string CUSTOMER_EMAIL_KEY = "customerEmail";
        const string CUSTOMER_TELEPHONE_KEY = "customerTelephone";
        const string CUSTOMER_INQUIRY_NOTES_KEY = "customerInquiryNotes";
        const string PRODUCT_ID_KEY = "productId";
        const string INQUIRY_SUCCESS_KEY = "inquirySuccess";
        public async Task<IActionResult> InquiryForm(int productId, string productPartNumber)
        {
            InquiryFormStub model = new InquiryFormStub();
            model.productId = productId;
            model.productPartNumber = productPartNumber;
            return await Task.FromResult(PartialView(model));
        }

        [HttpPost]
        public async Task<IActionResult> InquiryForm(InquiryFormStub modal)
        {
            HttpResponseMessage responseMessage = await HttpClientRequest.PostAsync(ApiEndpoints.AddProductInquiry, ConstructProductInquiryParams(modal));

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                InquiryResponseModel responseModel = JsonConvert.DeserializeObject<InquiryResponseModel>(
                        await responseMessage.Content.ReadAsStringAsync());

                if (responseModel.code == 2030)
                {
                    SaveInquirySuccessSession(responseModel.messages);

                    return RedirectToAction("Index", "Home", new { area = "ProductList", searchingKey = modal.productPartNumber });
                }
            } else
            {
                //return RedirectToAction("Index", "Home", new { area = "ProductList", searchingKey = productsParam.searchingKey });
            }

            return null;
        }

        private Dictionary<string, string> ConstructProductInquiryParams(InquiryFormStub modal)
        {
            return new Dictionary<string, string>
            {
                { CUSTOMER_EMAIL_KEY, modal.customerEmail },
                { CUSTOMER_TELEPHONE_KEY, modal.customerTelephone },
                { CUSTOMER_INQUIRY_NOTES_KEY, modal.customerInquiryNotes },
                { PRODUCT_ID_KEY, modal.productId.ToString() }
            };
            
        }

        private void SaveInquirySuccessSession(Object inquiryMessage)
        {
            HttpContext.Session.SetObject(INQUIRY_SUCCESS_KEY, inquiryMessage);
        }
    }
}