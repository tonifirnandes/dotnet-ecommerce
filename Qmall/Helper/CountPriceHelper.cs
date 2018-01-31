using Common.Enums;
using Qmall.Enum;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static Qmall.Models.PriceType.PriceTypeModel;
using Qmall.Models.ProductDetail;

namespace Qmall.Helper
{
    public class CountPriceHelper
    {
        public OriginalPrice CountOriginalPrice(PriceList price)
        {
            OriginalPrice originalPrice = new OriginalPrice();

            originalPrice.priceType = price.priceType;
            originalPrice.priceValue = ConvertCurrencyIDR(price.priceValue);
            originalPrice.priceStatus = price.priceStatus;

            return originalPrice;
        }

        public DiscountPrice CountDiscountPrice(PriceList price)
        {
            DiscountPrice discountPrice = new DiscountPrice();

            discountPrice.priceType = price.priceType;
            discountPrice.priceValue = ConvertCurrencyIDR(price.priceValue);
            discountPrice.priceStatus = price.priceStatus;

            return discountPrice;
        }

        public SpecialPrice CountSpecialPrice(PriceList price)
        {
            SpecialPrice specialPrice = new SpecialPrice();

            specialPrice.priceType = price.priceType;
            specialPrice.priceValue = ConvertCurrencyIDR(price.priceValue);
            specialPrice.priceStatus = price.priceStatus;

            return specialPrice;
        }

        public string CountFinalPrice(PriceList price)
        {
            string finalPrice = ConvertCurrencyIDR(price.priceValue);

            return finalPrice;
        }

        public string ConvertCurrencyIDR(string price)
        {
            CultureInfo culture = new CultureInfo("id-ID");
            double tempPriceValue = double.Parse(price);

            string result = tempPriceValue.ToString("C2", culture);
            result = result.Insert(2, " ");

            return result;
        }

        public string CountDiscountPrice(List<PriceList> priceList)
        {
            double originPrice = new double(), discPrice = new double();

            foreach (var price in priceList)
            {
                if (price.priceType == PriceType.ORIGINAL.ToString())
                {
                    originPrice = double.Parse(price.priceValue);
                }
                else if (price.priceType == PriceType.DISCOUNT.ToString())
                {
                    discPrice = double.Parse(price.priceValue);
                }
            }

            var countPrice = (discPrice / originPrice) * 100;
            var percentage = Convert.ToInt32(Math.Round(countPrice, 0));


            return percentage.ToString();
        }
    }
}
