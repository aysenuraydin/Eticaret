using System.ComponentModel.DataAnnotations;

namespace Eticaret.Web.Mvc.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = null!;

    }
}