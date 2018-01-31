using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models
{
    public class SubscribeEmailModel : BaseApiSingleResponseModel<ObjectSubscribeEmail>
    {
    }

    public class ObjectSubscribeEmail
    {
        public int fieldCount { get; set; }
        public int affectedRows { get; set; }
        public int insertId { get; set; }
        public int serverStatus { get; set; }
        public int warningCount { get; set; }
        public string message { get; set; }
        public bool protocol41 { get; set; }
        public int changedRows { get; set; }
    }
}
