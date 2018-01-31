using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.SideMenu.Models
{
    public class SideMenuViewModel
    {
        public List<SideMenuModel> sideMenuList { get; set; }

        public SideMenuViewModel(List<SideMenuModel> sideMenuData)
        {
            sideMenuList = sideMenuData;
        }
    }

}
