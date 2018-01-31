using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qmall.Models;
using Qmall.Repositories;

namespace Qmall.Areas.FooterBestSellerProducts.Controllers
{
    [Area("FooterBestSellerProducts")]
    public class FooterBestSellerController : Controller
    {
        IProductRepository ProductRepository;

        public FooterBestSellerController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ProductsTopViewModel productsTopViewModel = await ProductRepository.GetTopViewAsync();

            return PartialView(productsTopViewModel);
        }
    }
}