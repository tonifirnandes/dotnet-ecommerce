using Qmall.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.ProductDetail
{
    public class ProductDetailBaseModel
    {
        public SessionViewModel session { get; set; }
        public ProductDetailViewModel productView { get; set; }
    }
}
