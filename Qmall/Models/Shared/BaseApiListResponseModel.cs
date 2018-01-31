using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.Shared
{
    public class BaseApiListResponseModel<T> : BaseApiResponseModel
    {
        public List<T> data { get; set; }
    }
}
