using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.PriceType
{
    public class PriceTypeModel
    {
        public class OriginalPrice
        {
            public string priceType { get; set; }
            public string priceValue { get; set; }
            public string priceStatus { get; set; }
        }

        public class DiscountPrice
        {
            public string priceType { get; set; }
            public string priceValue { get; set; }
            public string priceStatus { get; set; }
        }

        public class SpecialPrice
        {
            public string priceType { get; set; }
            public string priceValue { get; set; }
            public string priceStatus { get; set; }
        }
    }
}
