using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Login.Models
{
    public class LoginFormModel
    {
        private const string EmailPattern = "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";

        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(EmailPattern, ErrorMessage = "e-mail is not valid")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Field is required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
