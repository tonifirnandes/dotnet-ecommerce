using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Newsletter.Models
{
    public class NewsletterViewModel
    {
        public List<ObjectNewsletter> NewsletterList { get; set; }
        public NewsletterViewModel(List<ObjectNewsletter> newsletterList)
        {
            NewsletterList = newsletterList;
        }
    }
}
