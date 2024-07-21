using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class SellerProductListDTO : AdminProductListDTO
    {
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori alanı gereklidir.")]
        public int CategoryId { get; set; }
    }

    public class SellerProductUpdateDTO
    {
        [Required]
        public int Id { get; set; }

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

        [Display(Name = "Ürün Resimleri")]
        public List<string> ImageList { get; set; } = new();

        [Display(Name = "Stok Adedi")]
        [Required(ErrorMessage = "Stok adedi alanı gereklidir.")]
        [Range(1, 255, ErrorMessage = "Ürün adedi 1 ile 255 arasında olmalıdır.")]
        public byte StockAmount { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori alanı gereklidir.")]
        public int CategoryId { get; set; }

        [Display(Name = "Satıcı")]
        public int SellerId { get; set; }

        [Display(Name = "Satışta Mı?")]
        public bool Enabled { get; set; }
    }

    public class SellerProductCreateDTO
    {
        public int Id { get; set; }

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

        [Display(Name = "Ürün Resimleri")]
        public List<UpdateImage> ImageList { get; set; } = new();

        [Display(Name = "Stok Adedi")]
        [Required(ErrorMessage = "Stok adedi alanı gereklidir.")]
        [Range(1, 255, ErrorMessage = "Ürün adedi 1 ile 255 arasında olmalıdır.")]
        public byte StockAmount { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori alanı gereklidir.")]
        public int CategoryId { get; set; }

        [Display(Name = "Satıcı")]
        public int SellerId { get; set; }

        [Display(Name = "Satışta Mı?")]
        public bool Enabled { get; set; }
    }

    public class UpdateImage
    {
        [Display(Name = "Resim URL")]
        [Required(ErrorMessage = "Resim URL alanı gereklidir.")]
        public string Url { get; set; } = null!;

        [Display(Name = "Ürün")]
        [Required(ErrorMessage = "Ürün alanı gereklidir.")]
        public int ProductId { get; set; }

        [Display(Name = "Satıcı")]
        [Required(ErrorMessage = "Satıcı alanı gereklidir.")]
        public int SellerId { get; set; }
    }
}
