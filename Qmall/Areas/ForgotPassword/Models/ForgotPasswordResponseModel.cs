using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.ForgotPassword.Models
{
    public class ForgotPasswordResponseModel : BaseApiListResponseModel<ObjectForgotPassword>
    {
    }
    public class ObjectForgotPassword
    {
        public int customerForgotPasswordId { get; set; }
        public string customerEmail { get; set; }
        public string customerForgotPasswordCode { get; set; }
    }
}
