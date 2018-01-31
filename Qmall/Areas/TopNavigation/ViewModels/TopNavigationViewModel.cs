using Qmall.Areas.Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.TopNavigation.ViewModels
{
    public class TopNavigationViewModel
    {
        public LoginComponent UserLoginSession { get; set; }
        public BaseWebContactInfo WebContact = new BaseWebContactInfo();

        public TopNavigationViewModel(LoginComponent userLoginSession)
        {
            UserLoginSession = userLoginSession;
        }

        public class BaseWebContactInfo
        {
            public string NoTelpActionLink { get; set; }
            public string NoTelpTextFormatted { get; set; }
            public string EmailAction { get; set; }

            public BaseWebContactInfo()
            {
                //Todo : gather info dynamic
                this.NoTelpActionLink = "tel:+622122524924";
                this.NoTelpTextFormatted = "(021) 2252-4924";
                this.EmailAction = "mailto:sales@sistemseiki.com?subject=Contact%20from%20sistem%20seiki%20web%20profile&body=Contact%20from%20sistem%20seiki%20web%20profile";
            }


        }
    }
}
