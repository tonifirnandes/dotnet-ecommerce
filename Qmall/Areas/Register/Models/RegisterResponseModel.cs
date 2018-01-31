using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Register.Models
{
    public class RegisterResponseModel : BaseApiListResponseModel<ObjectRegister>
    {
    }

    public class ObjectRegister
    {
        public int customerOtpCode { get; set; }
    }
}
