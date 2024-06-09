using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class AdminUserListDTO
    {
        [Required(ErrorMessage = "Kullanıcı ID'si gereklidir.")]
        [Display(Name = "Kullanıcı ID")]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi formatı.")]
        [Display(Name = "E-posta")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Tam ad alanı gereklidir.")]
        [MaxLength(100, ErrorMessage = "Tam ad en fazla 100 karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Tam Ad")]
        public string? FullName { get; set; }

        [Display(Name = "Etkin mi?")]
        public bool Enabled { get; set; } = false;

        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        [Display(Name = "Oluşturma Tarihi")]
        public string? CreatedAt { get; set; }

        [Required(ErrorMessage = "Rol adı alanı gereklidir.")]
        [Display(Name = "Rol Adı")]
        public string? RoleName { get; set; }

        [Display(Name = "Ad")]
        public string? FirstName { get; set; }

        [Display(Name = "Soyad")]
        public string? LastName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Sepet öğe sayısı negatif olamaz.")]
        [Display(Name = "Sepet Öğesi Sayısı")]
        public int CartItemCount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Ürün yorumu sayısı negatif olamaz.")]
        [Display(Name = "Ürün Yorumu Sayısı")]
        public int ProductCommentCount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Sipariş sayısı negatif olamaz.")]
        [Display(Name = "Sipariş Sayısı")]
        public int OrderCount { get; set; }
    }

    public class AdminUserUpdateDTO
    {
        [Required(ErrorMessage = "Kullanıcı ID'si gereklidir.")]
        [Display(Name = "Kullanıcı ID")]
        public int Id { get; set; }

        [Display(Name = "Etkin mi?")]
        public bool Enabled { get; set; }
    }

    public class UserUpdateDTO
    {
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [MinLength(2, ErrorMessage = "Ad en az 2 karakterden oluşmalıdır.")]
        [MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter uzunluğunda olmalıdır.")]
        public string? FirstName { get; set; }
        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "Soyadı alanı gereklidir.")]
        [MinLength(2, ErrorMessage = "Soyadı en az 2 karakterden oluşmalıdır.")]
        [MaxLength(50, ErrorMessage = "Soyadı en fazla 50 karakter uzunluğunda olmalıdır.")]
        public string? LastName { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail adresi alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string? Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [MinLength(1, ErrorMessage = "Şifre en az 1 karakterden oluşmalıdır.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
