using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Inquiry.Models
{
    public class InquiryFormStub
    {
        [Required]
        [Display(Name = "Email")]      
        public string customerEmail { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        public string customerTelephone { get; set; }
        [Required]
        [Display(Name = "Notes")]
        public string customerInquiryNotes { get; set; }
        public int productId { get; set; }
        public string productPartNumber { get; set; }
    }
}
