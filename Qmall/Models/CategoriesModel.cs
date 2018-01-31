using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models
{
    public class CategoriesModel : BaseApiListResponseModel<ObjectCategories>
    {
    }
    public class ObjectCategories
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
