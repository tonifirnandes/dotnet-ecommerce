using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qmall.Areas.Login.Models;
using Qmall.Areas.ProductDetail.Models;
using Qmall.Controllers;
using Qmall.Extensions;
using Qmall.Models;
using Qmall.Models.ProductDetail;
using Qmall.Repositories;

namespace Qmall.Areas.ProductDetail.Controllers {
    [Area ("ProductDetail")]
    public class HomeController : Controller {
        IProductDetailRepository ProductDetailRepository;
        const string PRODUCT_ID_KEY = "productId";
        const string PRODUCT_BRAND_ID_KEY = "productBrandId";
        const string EQUALCHAR = "=";
        const string ANDCHAR = "&";
        const string USER_LOGIN_SESSION_KEY = "USER_LOGIN_SESSION";

        public HomeController (IProductDetailRepository productDetailRepository) {
            ProductDetailRepository = productDetailRepository;
        }

        public async Task<IActionResult> Index (string productId, string productBrandId) {
            ProductDetailPresentationModel model;
            string parameters = PRODUCT_ID_KEY + EQUALCHAR + productId + ANDCHAR +
                PRODUCT_BRAND_ID_KEY + EQUALCHAR + productBrandId;
            LoginComponent sessionModel = await GetUserSession ();

            if (sessionModel != null)
                model = await GetProductDetailAfterLogin (parameters, sessionModel);
            else
                model = await GetProductDetailBeforeLogin (parameters);

            return View (model);
        }

        private async Task<LoginComponent> GetUserSession () {
            return await Task.FromResult (HttpContext.Session.GetObject<LoginComponent> (USER_LOGIN_SESSION_KEY));
        }

        private async Task<ProductDetailPresentationModel> GetProductDetailAfterLogin (string parameters, LoginComponent sessionModel) {
            ProductDetailBaseModel productDetailBase = await ProductDetailRepository.GetAsyncParamDetailLogin (parameters, sessionModel.customerEmail, sessionModel.customerToken);
            ProductDetailPresentationModel model = new ProductDetailPresentationModel (productDetailBase);

            return await Task.FromResult (model);
        }

        private async Task<ProductDetailPresentationModel> GetProductDetailBeforeLogin (string parameters) {
            ProductDetailViewModel productDetailView = await ProductDetailRepository.GetAsyncParam (parameters);
            ProductDetailPresentationModel model = new ProductDetailPresentationModel (productDetailView);

            return await Task.FromResult (model);
        }
    }
}