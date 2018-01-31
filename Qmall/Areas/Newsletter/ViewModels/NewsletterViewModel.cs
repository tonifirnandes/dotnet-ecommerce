using Qmall.Areas.Login.Models;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Newsletter.ViewModels
{
    public class NewsletterViewModel
    {
        public List<ObjectNewsletter> NewsletterList { get; set; }

        public NewsletterViewModel(List<ObjectNewsletter> newsletterList)
        {            
            NewsletterList = new List<ObjectNewsletter>(newsletterList.Capacity);
            NewsletterList.AddRange(newsletterList);
        }
        
    }
}
