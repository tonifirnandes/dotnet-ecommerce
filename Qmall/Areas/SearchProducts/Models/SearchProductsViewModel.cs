using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.SearchProducts.Models
{
    public class SearchProductsViewModel : BaseApiListResponseModel<ObjectSearchResult>
    {
    }

    public class ObjectSearchResult
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
