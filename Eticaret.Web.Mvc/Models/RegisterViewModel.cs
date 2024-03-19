using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Domain;

namespace Eticaret.Web.Mvc.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string? Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string? ConfirmPassword { get; set; } = string.Empty;

    }
}