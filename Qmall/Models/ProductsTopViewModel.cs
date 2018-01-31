using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models
{
    public class ProductsTopViewModel : BaseApiListResponseModel<ObjectProductsTopView>
    {
    }

    public class ObjectProductsTopView
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productPartNumber { get; set; }
        public int productStock { get; set; }
        public string productSpesification { get; set; }
        public string productDescription { get; set; }
        public double productWeight { get; set; }
        public string productDownloadLink { get; set; }
        public int productCategoryId { get; set; }
        public int productBrandId { get; set; }
        public int sellingNumber { get; set; }
        public int viewingNumber { get; set; }
    }
}
