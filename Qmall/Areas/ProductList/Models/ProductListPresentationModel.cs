using System;
using System.Collections.Generic;
using System.Globalization;
using Qmall.Areas.SearchProducts.Models;

namespace Qmall.Areas.ProductList.Models {
    public class ProductListPresentationModel {
        const string QUESTION_MARK_CHAR = "?";
        const string EQUALCHAR = "=";
        const string ENDCHAR = "&";
        const string PRODUCT_ID_KEY = "productId";
        const string PRODUCT_BRAND_ID_KEY = "productBrandId";

        public string Images { get; set; }
        public string PartNumber { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public string Price { get; set; }
        public string Button { get; set; }
        public ProductListPresentationModel () { }
        public ProductListPresentationModel (ObjectSearchResult product) {
            CultureInfo culture = new CultureInfo ("id-ID");

            string parameter = QUESTION_MARK_CHAR + PRODUCT_ID_KEY + EQUALCHAR + product.productId.ToString () + ENDCHAR +
                PRODUCT_BRAND_ID_KEY + EQUALCHAR + product.productBrandId.ToString();           

            Images = product.productImagesPath;
            PartNumber = product.productPartNumber;
            Brand = product.productName;
            Stock = product.productStock;
            if (product.productPriceNow != null) {
                Price = Decimal.Parse (product.productPriceNow.ToString ()).ToString ("C", culture);
            } else {
                Price = "<a href='/Login/Form'>Login First</a>";
            }

            Button = "<a href='/ProductDetail/Home/Index" + parameter + "' class='btn btn-success'>Detail</a>";

        }
        public List<ProductListPresentationModel> MapList (List<ObjectSearchResult> productList) {
            List<ProductListPresentationModel> result = new List<ProductListPresentationModel> ();

            foreach (var singleProduct in productList) {
                result.Add (new ProductListPresentationModel (singleProduct));
            }

            return result;
        }
    }
}