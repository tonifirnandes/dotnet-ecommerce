using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.Session
{
    public class SessionViewModel
    {
        public int code { get; set; }
        public string messages { get; set; }
        public List<SessionModel> rowss { get; set; }
    }
}
