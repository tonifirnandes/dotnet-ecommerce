using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models.Session
{
    public class SessionModel
    {
        public int customerSessionId { get; set; }
        public string customerEmail { get; set; }
        public string customerPhoneNumber { get; set; }
        public DateTime updateTimeCustomerSession { get; set; }
        public DateTime expireTimeCustomerSession { get; set; }
        public string customerToken { get; set; }
        public string customerAccess { get; set; }
    }
}
