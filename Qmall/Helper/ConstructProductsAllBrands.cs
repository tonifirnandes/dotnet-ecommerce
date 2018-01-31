using Qmall.Areas.Login.Models; 
using Qmall.Areas.SearchProducts.Models; 
using Qmall.Repositories; 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace Qmall.Helper {
    public class ConstructProductsAllBrands {
        IProductRepository ProductRepository; 
        public ConstructProductsAllBrands(IProductRepository productRepository) {
            ProductRepository = productRepository; 
        }

        public async Task < SearchProductsViewModel > GetProductsSingleBrand(string parameters, LoginComponent sessionModel) {
            SearchProductsViewModel searchProductsViewModel; 
            searchProductsViewModel = await ProductRepository.SearchFilter(parameters, 
                sessionModel != null?sessionModel.customerEmail:"", sessionModel != null?sessionModel.customerToken:""); 

            return searchProductsViewModel; 
        }
    }
}
