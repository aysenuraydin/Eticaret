using System.ComponentModel.DataAnnotations;
using Eticaret.Domain.Abstract;
using Microsoft.AspNetCore.Identity;
namespace Eticaret.Domain
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [MinLength(2, ErrorMessage = "Ad en az 2 karakterden oluşmalıdır.")]
        [MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter uzunluğunda olmalıdır.")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "Soyadı alanı gereklidir.")]
        [MinLength(2, ErrorMessage = "Soyadı en az 2 karakterden oluşmalıdır.")]
        [MaxLength(50, ErrorMessage = "Soyadı en fazla 50 karakter uzunluğunda olmalıdır.")]
        public string LastName { get; set; } = null!;
        [Display(Name = "Olaylı Mı?")]
        public bool Enabled { get; set; } = false;
        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Display(Name = "Rol Id")]
        [Required(ErrorMessage = "Rol alanı gereklidir.")]
        public int RoleId { get; set; } = 2;

        public string FullName => $"{FirstName} {LastName}";
        #region Navigation Properties
        public Role RoleFk { get; set; } = null!;
        [Display(Name = "Sepettekiler")]
        public List<CartItem> CartItems { get; set; } = new();
        [Display(Name = "Ürün Yorumları")]
        public List<ProductComment> ProductComments { get; set; } = new();
        [Display(Name = "Ürün Siparişleri")]
        public List<Order> Orders { get; set; } = new();
        #endregion

        //Seller
        #region Navigation Properties
        [Display(Name = "Satıcı Ürünleri")]
        public List<Product> Products { get; set; } = new();

        [Display(Name = "Ürün Resimleri")]
        public List<ProductImage> ProductImages { get; set; } = new();
        [Display(Name = "Siparişleri")]
        public List<OrderItem> OrderItems { get; set; } = new();
        #endregion
    }
}


