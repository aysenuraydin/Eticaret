using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.Web.Mvc.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail adresi alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } = null!;
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [MinLength(1, ErrorMessage = "Şifre en az 1 karakterden oluşmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}