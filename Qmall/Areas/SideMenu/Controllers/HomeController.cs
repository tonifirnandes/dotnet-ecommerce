using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Qmall.Models;
using Qmall.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Qmall.Areas.SideMenu.ViewModels;

namespace Qmall.Areas.SideMenu.Controllers
{
    [Area("SideMenu")]
    public class HomeController : Controller
    {
        private readonly IBrandRepository BrandRepository;
        private readonly ICategoryRepository CategoryRepository;
        public HomeController (IBrandRepository brandRepository, ICategoryRepository categoryRepository)
        {
            BrandRepository = brandRepository;
            CategoryRepository = categoryRepository;
        }       

        [HttpGet]
        public async Task<IActionResult> Index()
        {           
            return PartialView(new SideMenuViewModel(await BrandRepository.GetAsync(), await CategoryRepository.GetAsync()));
        }

    }
}