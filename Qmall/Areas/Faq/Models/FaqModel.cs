using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Faq.Models
{
    public class FaqModel : BaseApiListResponseModel<ObjectFaq>
    {
    }

    public class ObjectFaq
    {
        public int faqId { get; set; }
        public string faqQuestion { get; set; }
        public string faqAnswer { get; set; }
        public string faqDetail { get; set; }
    }
}
