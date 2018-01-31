using Qmall.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Models
{
    public class NewsletterModel : BaseApiListResponseModel<ObjectNewsletter>
    {
    }
    public class ObjectNewsletter
    {
        public int newsletterId { get; set; }
        public string newsletterDescription { get; set; }
        public string newsletterDetail { get; set; }
        public string newsletterImage { get; set; }
    }
}
