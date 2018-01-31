using Qmall.Enum;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.ProductList.Models
{
    public class ProductListViewModel
    {
        public string ProductBrandId { get; set; }
        public string SearchingKey { get; set; }
        public ProductListViewModel(string productBrandId, string searchingKey)
        {
            ProductBrandId = productBrandId;
            SearchingKey = searchingKey;
        }
    }
}
