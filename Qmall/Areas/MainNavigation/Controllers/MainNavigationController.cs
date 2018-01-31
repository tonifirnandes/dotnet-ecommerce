using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Qmall.Areas.MainNavigation.Models;
using Qmall.Areas.ProductList.Models;
using Qmall.Models;
using Qmall.Repositories;

namespace Qmall.Areas.MainNavigation.Controllers
{
    [Area("MainNavigation")]
    public class MainNavigationController : Controller
    {
        private IBrandRepository BrandRepository;
        public MainNavigationController(IBrandRepository brandRepository)
        {
            BrandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            BrandsModel brandsModel = await BrandRepository.GetAsync();
            List<ObjectBrands> brandList = brandsModel.data;

            return PartialView(new MainNavigationViewModel(brandList));
        }
    }
}