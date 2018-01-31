using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models
{
    public class ProductsModel : BaseApiListResponseModel<ProductsComponent>
    {
    }

    public class ProductsComponent
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productPartNumber { get; set; }
        public int productStock { get; set; }
        public int productWeight { get; set; }
        public int? productPriceNow { get; set; }
        public string productImagesPath { get; set; }
        public int productBrandId { get; set; }
    }
}
