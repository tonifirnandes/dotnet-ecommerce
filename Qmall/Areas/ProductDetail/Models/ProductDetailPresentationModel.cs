using Common.Enums;
using Qmall.Enum;
using Qmall.Helper;
using Qmall.Models;
using Qmall.Models.ProductDetail;
using Qmall.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Qmall.Models.PriceType.PriceTypeModel;

namespace Qmall.Areas.ProductDetail.Models
{
    public class ProductDetailPresentationModel
    {
        public ProductDetailModel ProductDetail { get; set; }
        public OriginalPrice originalPrice { get; set; }
        public DiscountPrice discountPrice { get; set; }
        public SpecialPrice specialPrice { get; set; }
        public string finalPrice { get; set; }
        public string productsDiscount { get; set; }

        public ProductDetailPresentationModel(ProductDetailBaseModel productDetailBaseModel)
        {
            ProductDetail = productDetailBaseModel.productView.data.FirstOrDefault();
            foreach (var price in ProductDetail.priceList)
            {
                FillPriceModel(price);
                FillFinalPrice(price);
            }
            FillDiscountPrice(ProductDetail.priceList);
        }

        public ProductDetailPresentationModel(ProductDetailViewModel productDetailView)
        {
            ProductDetail = productDetailView.data.FirstOrDefault();
        }

        public void FillPriceModel(PriceList price)
        {
            EnumHelper eh = new EnumHelper();
            CountPriceHelper formula = new CountPriceHelper();

            if (price.priceType == eh.GetEnumDescription(PriceType.ORIGINAL))
            {
                originalPrice = formula.CountOriginalPrice(price);
            }
            else if (price.priceType == eh.GetEnumDescription(PriceType.DISCOUNT))
            {
                discountPrice = formula.CountDiscountPrice(price);
            }
            else if (price.priceType == eh.GetEnumDescription(PriceType.SPECIAL))
            {
                specialPrice = formula.CountSpecialPrice(price);
            }
        }

        public void FillFinalPrice(PriceList price)
        {
            CountPriceHelper formula = new CountPriceHelper();

            if (price.priceStatus == PriceStatus.ACTIVE.ToString())
            {
                finalPrice = formula.CountFinalPrice(price);
            }
        }

        public void FillDiscountPrice(List<PriceList> priceList)
        {
            CountPriceHelper formula = new CountPriceHelper();

            productsDiscount = formula.CountDiscountPrice(priceList);
        }

    }
}
