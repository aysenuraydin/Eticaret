


using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Eticaret.Domain
{
    public class User : BaseEntity
    {
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail adresi alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string? Email { get; set; }
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
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [MinLength(1, ErrorMessage = "Şifre en az 1 karakterden oluşmalıdır.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Olaylı Mı?")]
        public bool Enabled { get; set; } = false;
        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Display(Name = "Rol Id")]
        [Required(ErrorMessage = "Rol alanı gereklidir.")]
        public int RoleId { get; set; } = 2;

        #region Navigation Properties
        public Role RoleFk { get; set; } = null!;
        [Display(Name = "Sepettekiler")]
        public List<CartItem> CartItems { get; set; } = new();
        [Display(Name = "Ürün Yorumları")]
        public List<ProductComment> ProductComments { get; set; } = new();
        [Display(Name = "Ürün Siparişleri")]
        public List<Order> Orders { get; set; } = new();
        #endregion
    }
}


