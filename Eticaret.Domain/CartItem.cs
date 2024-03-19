
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class CartItem : BaseEntity
    {
        [Range(1, 255, ErrorMessage = "Ürün adedi 1 ile 255 arasında olmalıdır."),
        Display(Name = "Ürün Adedi")]
        public byte Quantity { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ürün")]
        public int ProductId { get; set; }

        [Display(Name = "Kullanıcı")]
        public int UserId { get; set; }

        #region Navigation Properties
        [Required(ErrorMessage = "Kullanıcı alanı boş bırakılamaz.")]
        public User? UserFk { get; set; } = null!;

        [Required(ErrorMessage = "Ürün alanı boş bırakılamaz.")]
        public Product? ProductFk { get; set; } = null!;
        #endregion
    }
}