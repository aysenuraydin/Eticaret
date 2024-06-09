using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class ProductDetailDTO
    {
        [Display(Name = "Ürün ID")]
        [Required(ErrorMessage = "Ürün ID alanı gereklidir.")]
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        [MaxLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        [MinLength(2, ErrorMessage = "Ürün adı en az 2 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün adı alanı gereklidir.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Ürün Ücreti")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Ürün ücreti alanı gereklidir.")]
        [Range(1, 1000000, ErrorMessage = "Ürün ücreti 1 ile 1000000 arasında olmalıdır.")]
        public decimal Price { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        [MaxLength(500, ErrorMessage = "Ürün açıklaması en fazla 500 karakter uzunluğunda olmalıdır.")]
        [MinLength(2, ErrorMessage = "Ürün açıklaması en az 2 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün açıklaması alanı gereklidir.")]
        public string Details { get; set; } = null!;

        [Display(Name = "Stok Adedi")]
        [Required(ErrorMessage = "Stok adedi alanı gereklidir.")]
        [Range(1, 255, ErrorMessage = "Ürün adedi 1 ile 255 arasında olmalıdır.")]
        public byte StockAmount { get; set; }

        [Display(Name = "Kategori ID")]
        [Required(ErrorMessage = "Kategori ID alanı gereklidir.")]
        public int CategoryId { get; set; }

        [Display(Name = "Kategori Adı")]
        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Kategori adı alanı gereklidir.")]
        public string CategoryName { get; set; } = null!;

        [Display(Name = "Satıcı Adı")]
        [MaxLength(100, ErrorMessage = "Satıcı adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Satıcı adı alanı gereklidir.")]
        public string SellerName { get; set; } = null!;

        [Display(Name = "Ürün Yorumları")]
        public List<Comment> ProductComments { get; set; } = new();

        [Display(Name = "Ürün Görselleri")]
        public List<Images> ProductImagesUrl { get; set; } = new();
    }

    public class Comment
    {
        [Display(Name = "Yorum ID")]
        [Required(ErrorMessage = "Yorum ID alanı gereklidir.")]
        public int Id { get; set; }

        [Display(Name = "Yorum Metni")]
        [MaxLength(500, ErrorMessage = "Yorum metni en fazla 500 karakter uzunluğunda olmalıdır.")]
        public string? Text { get; set; }

        [Display(Name = "Yıldız Sayısı")]
        [Range(1, 5, ErrorMessage = "Yıldız sayısı 1 ile 5 arasında olmalıdır.")]
        public byte StarCount { get; set; }

        [Display(Name = "Onaylı Mı?")]
        public bool IsConfirmed { get; set; } = false;

        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public string CreatedAt { get; set; } = string.Empty;

        [Display(Name = "Kullanıcı Adı")]
        [MaxLength(100, ErrorMessage = "Kullanıcı adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        public string? UserName { get; set; }
    }

    public class Images
    {
        [Display(Name = "Görsel ID")]
        [Required(ErrorMessage = "Görsel ID alanı gereklidir.")]
        public int Id { get; set; }

        [Display(Name = "Görsel URL'si")]
        [Required(ErrorMessage = "Görsel URL'si alanı gereklidir.")]
        [Url(ErrorMessage = "Geçersiz URL formatı.")]
        public string? Url { get; set; }
    }
}
