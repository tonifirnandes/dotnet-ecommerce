using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qmall.Areas.SideMenu.Models;
using Qmall.Models;
using Qmall.Repositories;

namespace Qmall.Areas.SideMenu.Controllers
{
    [Area("SideMenu")]
    public class SideMenuController : Controller
    {
        ICategoryRepository CategoryRepository;
        public SideMenuController(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return PartialView(new SideMenuViewModel(await GetSideMenuData()));
        }

        private async Task<List<SideMenuModel>> GetSideMenuData()
        {
            List<SideMenuModel> sideMenuModel;
            CategoriesModel taskCategoriesModel;

            taskCategoriesModel = await CategoryRepository.GetAsync();
            sideMenuModel = new List<SideMenuModel>();
            foreach (var singleCategori in taskCategoriesModel.data)
            {
                if (sideMenuModel.Any())
                {
                    if (sideMenuModel.Where(n => n.productBrandId == singleCategori.productBrandId).Any())
                        sideMenuModel.FirstOrDefault(n => n.productBrandId == singleCategori.productBrandId).categoriesMenu.Add(AddCategoriesMenu(singleCategori));
                    else
                        sideMenuModel.Add(AddBrandsMenu(singleCategori));
                }
                else
                    sideMenuModel.Add(AddBrandsMenu(singleCategori));
            }
            return sideMenuModel;
        }

        private SideMenuModel AddBrandsMenu(ObjectCategories categoriesData)
        {
            SideMenuModel brandsMenu = new SideMenuModel();

            brandsMenu.productBrandId = categoriesData.productBrandId;
            brandsMenu.productBrandDescription = categoriesData.productBrandDescription;
            brandsMenu.productBrandImage = categoriesData.productBrandImage;
            brandsMenu.categoriesMenu = new List<CategoriesMenu> { AddCategoriesMenu(categoriesData) };

            return brandsMenu;
        }

        private CategoriesMenu AddCategoriesMenu(ObjectCategories categoriesData)
        {
            CategoriesMenu categoriesMenu = new CategoriesMenu();

            categoriesMenu.productCategoryId = categoriesData.productCategoryId;
            categoriesMenu.productCategoryDescription = categoriesData.productCategoryDescription;
            categoriesMenu.productCategoryImage = categoriesData.productCategoryImage;

            return categoriesMenu;
        }
    }
}