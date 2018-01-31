using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.SideMenu.ViewModels
{
    public class SideMenuViewModel
    {       
        private readonly List<ObjectBrands> brandList;
        private readonly List<ObjectCategories> categoryList;
        public List<SideMenuModel> sideMenuList { get; set; }

        public SideMenuViewModel(BrandsModel brandsModel, CategoriesModel categoriesModel)
        {           
            brandList = brandsModel.data;
            categoryList = categoriesModel.data;

            ConstructSideMenu(brandList, categoryList);            
        }

        private void ConstructSideMenu(List<ObjectBrands> brandList, List<ObjectCategories> categoryList)
        {
            //Todo : add handler of abnormal data
            sideMenuList = new List<SideMenuModel>(brandList.Capacity);
            List<ObjectCategories> brandCategoryList = new List<ObjectCategories>(categoryList.Capacity);
            foreach (var brand in brandList)
            {                
                brandCategoryList.AddRange(categoryList.Where(category => category.productBrandId == brand.productBrandId));
                sideMenuList.Add(new SideMenuModel(brand, brandCategoryList));
                brandCategoryList.Clear();
            }
        }

        public class SideMenuModel
        {
            public ObjectBrands parentBrandCategory { get; set; }
            public List<ObjectCategories> subBrandCategoryList { get; set; }
            public SideMenuModel(ObjectBrands brandParent, List<ObjectCategories> brandCategoryList)
            {
                parentBrandCategory = new ObjectBrands();
                subBrandCategoryList = new List<ObjectCategories>();
                parentBrandCategory = brandParent;
                subBrandCategoryList.AddRange(brandCategoryList);
            }

        }

    }
}
