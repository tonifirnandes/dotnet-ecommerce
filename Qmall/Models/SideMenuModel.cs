using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models
{
    public class SideMenuModel
    {
        public int productBrandId { get; set; }
        public string productBrandDescription { get; set; }
        public string productBrandImage { get; set; }
        public List<CategoriesMenu> categoriesMenu { get; set; }
    }

    public class CategoriesMenu
    {
        public int productBrandCategoryId { get; set; }
        public int productBrandId { get; set; }
        public int productCategoryId { get; set; }
        public string productBrandDescription { get; set; }
        public string productBrandImage { get; set; }
        public string productCategoryDescription { get; set; }
        public string productCategoryImage { get; set; }
    }
}
