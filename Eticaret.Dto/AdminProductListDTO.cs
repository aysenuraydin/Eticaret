using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Eticaret.Dto
{
    public class AdminProductListDTO
    {
        [Required(ErrorMessage = "Ürün ID'si gereklidir.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı alanı gereklidir.")]
        [MaxLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Ürün fiyatı alanı gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Geçersiz ürün fiyatı.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Ürün resim URL listesi alanı gereklidir.")]
        public List<string?> ImageUrlList { get; set; } = new List<string?>();

        [Required(ErrorMessage = "Ürün detayları alanı gereklidir.")]
        public string Details { get; set; } = null!;

        [Required(ErrorMessage = "Stok miktarı alanı gereklidir.")]
        [Range(0, 255, ErrorMessage = "Geçersiz stok miktarı.")]
        public byte StockAmount { get; set; }

        public string? CategoryName { get; set; }
        public string? CategoryColor { get; set; }

        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public string? CreatedAt { get; set; }

        public bool Enabled { get; set; }
        public bool IsConfirmed { get; set; }

        [Required(ErrorMessage = "Satıcı adı alanı gereklidir.")]
        public string? SellerName { get; set; }

        [Required(ErrorMessage = "Yorum sayısı alanı gereklidir.")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçersiz yorum sayısı.")]
        public int CommentCount { get; set; }

        [Required(ErrorMessage = "Sipariş sayısı alanı gereklidir.")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçersiz sipariş sayısı.")]
        public int OrderCount { get; set; }

        [Required(ErrorMessage = "Sepet sayısı alanı gereklidir.")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçersiz sepet sayısı.")]
        public int CartCount { get; set; }
    }

    public class AdminProductUpdateDTO
    {
        [Required(ErrorMessage = "Ürün ID'si gereklidir.")]
        public int Id { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
