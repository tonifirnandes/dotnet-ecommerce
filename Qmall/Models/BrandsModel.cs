using Qmall.Models.Shared;
using System.Collections.Generic;

namespace Qmall.Models
{
    public class BrandsModel : BaseApiListResponseModel<ObjectBrands>
    {

    }

    public class ObjectBrands 
    {
        public int? productBrandId { get; set; }
        public string productBrandDescription { get; set; }
        public string productBrandImage { get; set; }
    }
}