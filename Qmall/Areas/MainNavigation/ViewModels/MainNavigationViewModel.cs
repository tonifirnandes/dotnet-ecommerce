using Qmall.Areas.Login.Models;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.MainNavigation.ViewModels
{
    public class MainNavigationViewModel
    {
        public List<ObjectBrands> BrandList { get; set; }
        public string QmallLogoUrl { get; set; }

        public MainNavigationViewModel(List<ObjectBrands> brandList)
        {            
            BrandList = new List<ObjectBrands>(brandList.Capacity);
            BrandList.AddRange(brandList);
            QmallLogoUrl = "../images/logo/qmall-logo.svg";
        }
        
    }
}
