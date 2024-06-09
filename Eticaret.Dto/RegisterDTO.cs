using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class RegisterDTO
    {
        [Display(Name = "Ad")]
        [MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter uzunluğunda olmalıdır.")]
        [MinLength(2, ErrorMessage = "Ad en az 2 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Soyad")]
        [MaxLength(50, ErrorMessage = "Soyad en fazla 50 karakter uzunluğunda olmalıdır.")]
        [MinLength(2, ErrorMessage = "Soyad en az 2 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "E-posta")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        [Required(ErrorMessage = "E-posta alanı gereklidir.")]
        public string Email { get; set; } = null!;

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string Password { get; set; } = null!;
    }
}
