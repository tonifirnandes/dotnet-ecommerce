using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Register.Models
{
    public class VerifiedModel
    {
        [Required]
        public string code { get; set; }
        public string verifiedCode { get; set; }
    }
}
