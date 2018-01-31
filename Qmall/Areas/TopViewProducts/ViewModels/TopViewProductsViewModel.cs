using Qmall.Areas.Login.Models;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.TopViewProducts.ViewModels
{
    public class TopViewProductsViewModel
    {
        public List<ObjectProductsTopView> TopViewProductList { get; set; }

        public TopViewProductsViewModel(List<ObjectProductsTopView> topViewProducts)
        {
            TopViewProductList = new List<ObjectProductsTopView>(topViewProducts.Capacity);
            TopViewProductList.AddRange(topViewProducts);
        }
        
    }
}
