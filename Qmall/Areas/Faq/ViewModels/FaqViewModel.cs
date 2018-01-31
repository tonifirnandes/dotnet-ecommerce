using Qmall.Areas.Faq.Models;
using Qmall.Areas.Login.Models;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Faq.ViewModels
{
    public class FaqViewModel
    {
        public List<ObjectFaq> FaqList { get; set; }

        public FaqViewModel(List<ObjectFaq> faqList)
        {
            FaqList = new List<ObjectFaq>(faqList.Capacity);
            FaqList.AddRange(faqList);
        }
        
    }
}
