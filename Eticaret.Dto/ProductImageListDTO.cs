using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class ProductImageListDTO
    {
        public int Id { get; set; }
        [Display(Name = "Görsel URL'si")]
        [Required(ErrorMessage = "Görsel URL'si alanı gereklidir.")]
        [Url(ErrorMessage = "Geçersiz URL formatı.")]
        public string? Url { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public string? CreatedAt { get; set; }

        [Display(Name = "Ürün ID")]
        [Required(ErrorMessage = "Ürün ID alanı gereklidir.")]
        public int ProductId { get; set; }

        [Display(Name = "Satıcı ID")]
        [Required(ErrorMessage = "Satıcı ID alanı gereklidir.")]
        public int SellerId { get; set; }
    }

    public class ProductImageCreateDTO
    {
        [Display(Name = "Görsel URL'si")]
        [Required(ErrorMessage = "Görsel URL'si alanı gereklidir.")]
        [Url(ErrorMessage = "Geçersiz URL formatı.")]
        public string? Url { get; set; }

        [Display(Name = "Ürün ID")]
        [Required(ErrorMessage = "Ürün ID alanı gereklidir.")]
        public int ProductId { get; set; }

        [Display(Name = "Satıcı ID")]
        [Required(ErrorMessage = "Satıcı ID alanı gereklidir.")]
        public int SellerId { get; set; }
    }
}
