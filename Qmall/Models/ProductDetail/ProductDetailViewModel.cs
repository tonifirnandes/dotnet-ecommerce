using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.ProductDetail
{
    public class ProductDetailViewModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<ProductDetailModel> data { get; set; }
    }
}
