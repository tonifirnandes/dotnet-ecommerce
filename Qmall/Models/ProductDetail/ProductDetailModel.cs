using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.ProductDetail {
    public class ProductDetailModel {
        public int productId { get; set; }
        public int productBrandId { get; set; }
        public int productCategoryId { get; set; }
        public int productPriceId { get; set; }
        public int productDeliveryTimeTypeId { get; set; }
        public int productDeliveryTimeId { get; set; }
        public string productDescription { get; set; }
        public int productWeight { get; set; }
        public string productDownloadLink { get; set; }
        public string productBrandDescription { get; set; }
        public string productBrandImage { get; set; }
        public string productName { get; set; }
        public string productPartNumber { get; set; }
        public int productStock { get; set; }
        public string productSpesification { get; set; }
        public string productCategoryDescription { get; set; }
        public string productCategoryImage { get; set; }
        public string productDeliveryTImeType { get; set; }
        public int productDeliveryTimeValue { get; set; }
        public int productDeliveryTimeMin { get; set; }
        public int productDeliveryTimeMax { get; set; }
        public int sortingDeliveryTime { get; set; }
        public List<PriceList> priceList { get; set; }
        public string productImagesPath { get; set; }
    }

    public class PriceList {
        public string priceType { get; set; }
        public string priceValue { get; set; }
        public string priceStatus { get; set; }
    }
}