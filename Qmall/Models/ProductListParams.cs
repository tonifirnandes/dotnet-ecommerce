using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models
{
    public class ProductListParams
    {
        const string
            BRAND_FILTER_PARAM_KEY = "brandFilter",
            SEARCHING_KEY_FILTER_PARAM_KEY = "searchingkey",
            STOCKS_FILTER_PARAM_KEY = "stocks",
            DELIVERY_TIME_FILTER_PARAM_KEY = "deliveryTimeFilter",
            SORTING_OPTION_FILTER_PARAM_KEY = "sortingOption",
            PAGE_FILTER_PARAM_KEY = "page",
            EQUAL_PARAM_KEY = "=",
            AND_FILTER_PARAM_KEY = "&",
            DELIMITTER_PARAM_KEY = ",",
            DEFAULT_SORTING_OPTION_PARAM_VALUE = "0",
            DEFAULT_PAGE_PARAM_VALUE = "0,10";

        public string brandFilter { get; set; }
        public string searchingKey { get; set; }
        public string stocks { get; set; }
        public string deliveryTimeFilter { get; set; }
        public string sortingOption { get; set; }
        public string page { get; set; }

        public ProductListParams(string brandFilter, string searchingKey, string stocks, string deliveryTimeFilter, string sortingOption, string page)
        {
            this.brandFilter = brandFilter;
            this.searchingKey = searchingKey;
            this.stocks = stocks;
            this.deliveryTimeFilter = deliveryTimeFilter;
            this.sortingOption = sortingOption;
            this.page = page;
        }
        private string GetBrandFilterParam()
        {
            return ConstructFilterParam(BRAND_FILTER_PARAM_KEY, brandFilter);
        }
        private string GetSearchingKeyFilterParam()
        {
            return ConstructFilterParam(SEARCHING_KEY_FILTER_PARAM_KEY, searchingKey);
        }
        private string GetStocksFilterParam()
        {
            return ConstructFilterParam(STOCKS_FILTER_PARAM_KEY, stocks);
        }
        private string GetDeliveryTimeFilterParam()
        {
            return ConstructFilterParam(DELIVERY_TIME_FILTER_PARAM_KEY, deliveryTimeFilter);
        }
        private string GetPageFilterParam()
        {
            return ConstructFilterParam(PAGE_FILTER_PARAM_KEY, !String.IsNullOrEmpty(page) ? page : DEFAULT_PAGE_PARAM_VALUE);
        }
        private string GetSortingOptionParam()
        {
            return ConstructFilterParam(SORTING_OPTION_FILTER_PARAM_KEY, !String.IsNullOrEmpty(sortingOption) ? sortingOption : DEFAULT_SORTING_OPTION_PARAM_VALUE);
        }
        private string ConstructFilterParam(string paramKey, string paramValue)
        {
            return paramKey + EQUAL_PARAM_KEY + paramValue;
        }
        public string GetProductListFilterParam()
        {
            string final = GetBrandFilterParam() + AND_FILTER_PARAM_KEY +
                GetSearchingKeyFilterParam() + AND_FILTER_PARAM_KEY +
                GetStocksFilterParam() + AND_FILTER_PARAM_KEY +
                GetDeliveryTimeFilterParam() + AND_FILTER_PARAM_KEY +
                GetSortingOptionParam() + AND_FILTER_PARAM_KEY +
                GetPageFilterParam();
            return final;
        }
        public static string ConstructMultipleBrandFilterParams(List<int> brandFilters)
        {
            return brandFilters.Count == 0 ? "" : string.Join<int>(DELIMITTER_PARAM_KEY,
                brandFilters.Where(i => i != 0).ToList());
        }
        public static string ConstructMultipleDeliveryTimeFilterParams(List<int> deliveryTimes)
        {
            return deliveryTimes.Count == 0 ? "" : string.Join<int>(DELIMITTER_PARAM_KEY,
                deliveryTimes.Where(i => i != 0).ToList());
        }
    }
}
