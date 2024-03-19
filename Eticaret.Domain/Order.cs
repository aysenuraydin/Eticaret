using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class Order : BaseEntity
    {
        [Display(Name = "Sipariş Kodu")]
        [Required(ErrorMessage = "Sipariş kodu alanı gereklidir.")]
        [MinLength(2, ErrorMessage = "Sipariş kodu en az 2 karakterden oluşmalıdır.")]
        public string? OrderCode { get; set; } = Guid.NewGuid().ToString();

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Adres alanı gereklidir.")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Adres en az 2, en fazla 250 karakter uzunluğunda olmalıdır.")]
        public string? Address { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Kullanıcı")]
        [Required(ErrorMessage = "Kullanıcı alanı gereklidir.")]
        public int UserId { get; set; }

        #region Navigation Properties
        public User UserFk { get; set; } = null!;

        [Display(Name = "Siparişler")]
        public List<OrderItem> OrderItems { get; set; } = new();
        #endregion
    }
}



