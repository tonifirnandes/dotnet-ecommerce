using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.MainNavigation.Models
{
    public class MainNavigationViewModel
    {
        public List<ObjectBrands> BrandList { get; set; }
        public string QmallLogoUrl { get; set; }
        public MainNavigationViewModel(List<ObjectBrands> brandList)
        {
            BrandList = brandList;
            QmallLogoUrl = "~/images/logo/qmall-logo.png";
        }
    }
}
