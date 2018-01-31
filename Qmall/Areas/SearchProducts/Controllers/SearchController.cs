using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Qmall.Areas.Login.Models;
using Qmall.Areas.SearchProducts.Models;
using Qmall.Extensions;
using Qmall.Helper;
using Qmall.Models;
using Qmall.Repositories;

namespace Qmall.Areas.SearchProducts.Controllers {
    [Area ("SearchProducts")]
    public class SearchController : Controller {
        IProductRepository ProductRepository;
        IBrandRepository BrandRepository;
        const int PRODUCT_AVAILABLE_CODE = 6000;

        public SearchController (IProductRepository productRepository, IBrandRepository brandRepository) {
            ProductRepository = productRepository;
            BrandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<string> Index (string productBrandId, string searchingKey) {
            LoginComponent sessionModel;
            SearchProductsViewModel searchProductsViewModel = new SearchProductsViewModel ();
            ConstructProductsAllBrands constructProducts = new ConstructProductsAllBrands (ProductRepository);

            sessionModel = await GetUserLoginSession ();
            searchProductsViewModel = await constructProducts.GetProductsSingleBrand (ConstructorParamQueryString.ParamQueryString (productBrandId, searchingKey).Result, sessionModel);

            return GenerateProductsModelAsStringJson (searchProductsViewModel);
        }

        [HttpGet]
        public async Task<int> GetBrandCount () {
            BrandsModel brandsModel = await BrandRepository.GetAsync();
            int result = brandsModel.data.Count() - 1;

            return result;
        }

        private async Task<LoginComponent> GetUserLoginSession () {
            return await Task.FromResult (
                HttpContext.Session.GetObject<LoginComponent> (SessionExtensionsMethods.USER_LOGIN_SESSION_KEY));
        }

        private string GenerateProductsModelAsStringJson (SearchProductsViewModel searchProductsViewModel) {
            string arrayProducts = "";
            List<ProductsSearchModel> productsSearchModel;

            productsSearchModel = new List<ProductsSearchModel> ();
            if (searchProductsViewModel.code == PRODUCT_AVAILABLE_CODE) {
                foreach (var single in searchProductsViewModel.data) {
                    ProductsSearchModel productSearch = new ProductsSearchModel ();

                    productSearch.value = single.productPartNumber;
                    productSearch.data = single.productId.ToString ();

                    productsSearchModel.Add (productSearch);
                }
                arrayProducts = JsonConvert.SerializeObject (productsSearchModel);
            } else {
                arrayProducts = JsonConvert.SerializeObject (productsSearchModel);
            }

            return arrayProducts;
        }
    }
}