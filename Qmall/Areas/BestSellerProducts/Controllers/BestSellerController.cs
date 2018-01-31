using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qmall.Models;
using Qmall.Repositories;

namespace Qmall.Areas.BestSellerProducts.Controllers
{
    [Area("BestSellerProducts")]
    public class BestSellerController : Controller
    {
        IProductRepository ProductRepository;
        public BestSellerController(IProductRepository productRepository)
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