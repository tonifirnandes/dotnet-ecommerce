using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Services.RestApi
{
    public static class ApiEndpoints
    {
        public const string BaseUrl = "/qmallstore";
       
        public const string SearchFilter = BaseUrl + "/searchproduct";
        public const string AllCategories = BaseUrl + "/allbrandallcategory";
        public const string AllBrands = BaseUrl + "/brandlist";
        public const string Newsletter = BaseUrl + "/newsletter";
        public const string ProductTopView = BaseUrl + "/topviewing";
        public const string SubscribeEmail = BaseUrl + "/insertsubcribeemail";
        public const string Login = BaseUrl + "/logincustomer";
        public const string Register = BaseUrl + "/registeremailcustomer";
        public const string VerificationCode = BaseUrl + "/checkotpcode";
        public const string ResendCode = BaseUrl + "/resendcode";
        public const string ForgotPassword = BaseUrl + "/emailcheckforgotpassword";
        public const string ResetPassword = BaseUrl + "/resetpassword";
        public const string AllProducts = BaseUrl + "/searchproductnolimit";
        public const string Faq = BaseUrl + "/faq";
        public const string ProductDetail = BaseUrl + "/productinfodetail";
        public const string AddProductInquiry = BaseUrl + "/addproductinquiry";
    }
}
