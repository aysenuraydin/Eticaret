using Eticaret.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class Product : BaseEntity
    {
        [Display(Name = "Ürün Adı")]
        [MaxLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        [MinLength(2, ErrorMessage = "Ürün adı en az 2 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün adı alanı gereklidir.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Ürün Ücreti")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Ürün ücreti alanı gereklidir.")]
        [Range(1, 1000000, ErrorMessage = "Ürün ücreti giriniz")]
        public decimal Price { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        [MaxLength(100, ErrorMessage = "Ürün açıklaması en fazla 100 karakter uzunluğunda olmalıdır.")]
        [MinLength(2, ErrorMessage = "Ürün açıklaması en az 2 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün açıklaması alanı gereklidir.")]
        public string Details { get; set; } = null!;

        [Display(Name = "Stok Adedi")]
        [Required(ErrorMessage = "Stok adedi alanı gereklidir.")]
        [Range(1, 255, ErrorMessage = "Ürün adedi 1 ile 255 arasında olmalıdır.")]
        public byte StockAmount { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Onaylı Mı?")]
        public bool IsConfirmed { get; set; } = false;

        [Display(Name = "Satışta Mı?")]
        public bool Enabled { get; set; } = false;
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori alanı gereklidir.")]
        public int CategoryId { get; set; }
        [Display(Name = "Satıcı")]
        [Required(ErrorMessage = "Satıcı alanı gereklidir.")]
        public int SellerId { get; set; }

        #region Navigation Properties
        public Seller? SellerFk { get; set; } = null!;
        public Category? CategoryFk { get; set; } = null!;
        [Display(Name = "Ürün Yorumları")]
        public List<ProductComment> ProductComments { get; set; } = new();
        [Display(Name = "Siparişler")]
        public List<OrderItem> OrderItems { get; set; } = new();
        [Display(Name = "Sepettekiler")]
        public List<CartItem> CartItems { get; set; } = new();
        [Display(Name = "Ürün Resimleri")]
        public List<ProductImage> ProductImages { get; set; } = new();
        #endregion
    }
}



