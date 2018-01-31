using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Register.Models
{
    
    public class RegisterFormModel
    {
        private const string EmailPattern = "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";
        private const string PasswordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$";
        private const string PasswordErrorMessage = "Password is not valid (min 6-20 characters with at least a digit, lowercase and uppercase letters, and special symbol in @@#$%";

        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(EmailPattern, ErrorMessage = "e-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(PasswordPattern, ErrorMessage = PasswordErrorMessage)]    
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Field is required")]
        [Compare("Password", ErrorMessage = "Confirmation password not match")]
        public string ConfirmPassword { get; set; }

    }
}
