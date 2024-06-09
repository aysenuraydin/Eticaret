using Eticaret.Domain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class OrderItem : BaseEntity
    {
        [Range(1, 255)]
        [Display(Name = "Sipariş Adedi")]
        [Required(ErrorMessage = "Sipariş adedi alanı gereklidir.")]
        public byte Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Ürün Fiyatı")]
        [Required(ErrorMessage = "Ürün fiyatı alanı gereklidir.")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ürün")]
        [Required(ErrorMessage = "Ürün alanı gereklidir.")]
        public int ProductId { get; set; }

        [Display(Name = "Sipariş")]
        [Required(ErrorMessage = "Sipariş alanı gereklidir.")]
        public int OrderId { get; set; }

        [Display(Name = "Satıcı")]
        [Required(ErrorMessage = "Satıcı alanı gereklidir.")]

        public int UserId { get; set; }

        #region Navigation Properties
        public Product ProductFk { get; set; } = null!;
        public Order OrderFk { get; set; } = null!;
        public User UserFk { get; set; } = null!;
        #endregion
    }

}