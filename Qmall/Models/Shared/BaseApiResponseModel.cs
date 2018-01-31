using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.Shared
{
    public class BaseApiResponseModel
    {
        public int code { get; set; }
        public string messages { get; set; }
        public bool success { get; set; }
        public string messageError { get; set; }
    }
}
