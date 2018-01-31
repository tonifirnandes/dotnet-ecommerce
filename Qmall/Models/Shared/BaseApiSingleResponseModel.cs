using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.Shared
{
    public class BaseApiSingleResponseModel<T> : BaseApiResponseModel
    {
        public T data { get; set; }
    }
}
