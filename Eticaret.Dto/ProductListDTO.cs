using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class ProductListDTO
    {
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
        [Range(1, 1000000, ErrorMessage = "Ürün ücreti 1 ile 1,000,000 arasında olmalıdır.")]
        public decimal Price { get; set; }

        [Display(Name = "Ürün Görsel URL'si")]
        [Required(ErrorMessage = "Ürün görsel URL'si alanı gereklidir.")]
        [Url(ErrorMessage = "Geçersiz URL formatı.")]
        public string ImageUrl { get; set; } = null!;
    }
}
