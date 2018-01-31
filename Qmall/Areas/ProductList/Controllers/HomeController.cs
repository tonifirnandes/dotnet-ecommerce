using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Qmall.Areas.Login.Models;
using Qmall.Areas.ProductList.Models;
using Qmall.Areas.SearchProducts.Models;
using Qmall.Controllers;
using Qmall.Extensions;
using Qmall.Helper;
using Qmall.Models;
using Qmall.Models.Shared;
using Qmall.Repositories;
using Qmall.Services;

namespace Qmall.Areas.ProductListing.Controllers {
    [Area ("ProductList")]
    public class HomeController : Controller {
        IProductRepository ProductRepository;
        const string INQUIRY_SUCCESS_KEY = "inquirySuccess";

        public HomeController (IProductRepository productRepository) {
            ProductRepository = productRepository;
        }

        public async Task<IActionResult> Index (string productBrandId = null, string searchingKey = null) {
            string messageSuccessInquiry = await GetInquiryMessageSession ();
            ViewData["inquiryMessageResult"] = messageSuccessInquiry;
            RemoveInquiryMessageSession ();
            return View (await GetProductListPageModel (productBrandId, searchingKey));
        }
        private async Task<ProductListViewModel> GetProductListPageModel (string productBrandId = null, string searchingKey = null) {
            ProductListViewModel productListPageModel = new ProductListViewModel (productBrandId, searchingKey);

            return await Task.FromResult (productListPageModel);
        }

        [HttpGet]
        public async Task<string> ProductListDataModelAsString (string productBrandId, string searchingKey) {
            LoginComponent sessionModel;
            SearchProductsViewModel searchProductsViewModel = new SearchProductsViewModel ();
            ConstructProductsAllBrands constructProducts = new ConstructProductsAllBrands(ProductRepository);

            sessionModel = await GetUserLoginSession ();
            searchProductsViewModel = await constructProducts.GetProductsSingleBrand (ConstructorParamQueryString.ParamQueryString (productBrandId, searchingKey).Result, sessionModel);
            string result = JsonConvert.SerializeObject(new ProductListPresentationModel().MapList(searchProductsViewModel.data));

            return result;
        }

        private async Task<LoginComponent> GetUserLoginSession () {
            return await Task.FromResult (
                HttpContext.Session.GetObject<LoginComponent> (SessionExtensionsMethods.USER_LOGIN_SESSION_KEY));
        }

        private async Task<string> GetInquiryMessageSession () {
            return await Task.FromResult (HttpContext.Session.GetObject<string> (INQUIRY_SUCCESS_KEY));
        }
        private void RemoveInquiryMessageSession () {
            HttpContext.Session.Remove (INQUIRY_SUCCESS_KEY);
        }
    }
}