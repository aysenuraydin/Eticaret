using Eticaret.Domain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class ProductImage : BaseEntity
    {
        [Display(Name = "Ürün URL")]
        [Required(ErrorMessage = "Ürün URL alanı gereklidir.")]
        [MinLength(10, ErrorMessage = "Ürün URL en az 10 karakterden oluşmalıdır.")]
        [MaxLength(250, ErrorMessage = "Ürün URL en fazla 250 karakter uzunluğunda olmalıdır.")]
        [DataType(DataType.Url, ErrorMessage = "Geçersiz URL formatı.")]
        public string? Url { get; set; } = Guid.NewGuid().ToString();

        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ürün")]
        [Required(ErrorMessage = "Ürün alanı gereklidir.")]
        public int ProductId { get; set; }

        [Display(Name = "Satıcı")]
        [Required(ErrorMessage = "Satıcı alanı gereklidir.")]
        public int SellerId { get; set; }
        #region Navigation Properties
        public Product ProductFk { get; set; } = null!;
        public Seller SellerFk { get; set; } = null!;
        #endregion
    }
}