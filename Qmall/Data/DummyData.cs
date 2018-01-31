using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Data
{
    public static class DummyData
    {
        public static CategoriesModel DummyCategoriesModel()
        {
            CategoriesModel listModel = new CategoriesModel();

            listModel.success = true;
            listModel.data = new List<ObjectCategories>()
            {
                new ObjectCategories
                    {
                        productBrandCategoryId = 1,
                        productBrandId = 1,
                        productCategoryId = 1,
                        productBrandDescription = "SMC",
                        productBrandImage = "http://www.smcusa.com/cad",
                        productCategoryDescription = "Arm Robot",
                        productCategoryImage = "http://www.robotshop.com/media/files/images/owi-535-robotic-arm-edge-large.jpg"
                    },
                    new ObjectCategories
                    {
                        productBrandCategoryId = 2,
                        productBrandId = 1,
                        productCategoryId = 2,
                        productBrandDescription = "SMC",
                        productBrandImage = "http://www.smcusa.com/cad",
                        productCategoryDescription = "Pneumatic",
                        productCategoryImage = "http://www.motorgearengineer.com/blog/wp-content/uploads/pneumatic_cylinder.jpg"
                    },
                    new ObjectCategories
                    {
                        productBrandCategoryId = 3,
                        productBrandId = 1,
                        productCategoryId = 3,
                        productBrandDescription = "SMC",
                        productBrandImage = "http://www.smcusa.com/cad",
                        productCategoryDescription = "Sikat Gigi",
                        productCategoryImage = "http://www.motorgearengineer.com/blog/wp-content/uploads/pneumatic_cylinder.jpg"
                    },
                    new ObjectCategories
                    {
                        productBrandCategoryId = 4,
                        productBrandId = 2,
                        productCategoryId = 1,
                        productBrandDescription = "Sun X",
                        productBrandImage = "http://www2.panasonic.co.jp/id/pidsx/e/",
                        productCategoryDescription = "Arm Robot",
                        productCategoryImage = "http://www.robotshop.com/media/files/images/owi-535-robotic-arm-edge-large.jpg"
                    },
                    new ObjectCategories
                    {
                        productBrandCategoryId = 5,
                        productBrandId = 2,
                        productCategoryId = 2,
                        productBrandDescription = "Sun X",
                        productBrandImage = "http://www2.panasonic.co.jp/id/pidsx/e/",
                        productCategoryDescription = "Pneumatic",
                        productCategoryImage = "http://www.motorgearengineer.com/blog/wp-content/uploads/pneumatic_cylinder.jpg"
                    },
                    new ObjectCategories
                    {
                        productBrandCategoryId = 6,
                        productBrandId = 2,
                        productCategoryId = 3,
                        productBrandDescription = "Sun X",
                        productBrandImage = "http://www2.panasonic.co.jp/id/pidsx/e/",
                        productCategoryDescription = "Sikat Gigi",
                        productCategoryImage = "http://www.motorgearengineer.com/blog/wp-content/uploads/pneumatic_cylinder.jpg"
                    },
                    new ObjectCategories
                    {
                        productBrandCategoryId = 7,
                        productBrandId = 2,
                        productCategoryId = 4,
                        productBrandDescription = "Sun X",
                        productBrandImage = "http://www2.panasonic.co.jp/id/pidsx/e/",
                        productCategoryDescription = "Sabun Mandi",
                        productCategoryImage = "http://www.motorgearengineer.com/blog/wp-content/uploads/pneumatic_cylinder.jpg"
                    },
            };

            return listModel;
        }
    }
}
