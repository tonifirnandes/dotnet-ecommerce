
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qmall.Repositories;
using Qmall.Models;
using System.Collections.Generic;
using Qmall.Areas.TopViewProducts.ViewModels;

namespace Qmall.Areas.TopViewProducts.Controllers
{
    [Area("TopViewProducts")]
    public class HomeController : Controller
    {
        private readonly IProductRepository ProductRepository;

        public HomeController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Todo : top product view / sell
            ProductsTopViewModel productTopViewModel = await ProductRepository.GetTopViewAsync();
            List<ObjectProductsTopView> productTopViewList = new List<ObjectProductsTopView>(productTopViewModel.data.Capacity);
            productTopViewList.AddRange(productTopViewModel.data);
            return PartialView(new TopViewProductsViewModel(productTopViewList));
        }
    }
}