using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class ProductCommentListDTO
    {
        [Display(Name = "Yorum Metni")]
        [MaxLength(500, ErrorMessage = "Yorum metni en fazla 500 karakter uzunluğunda olmalıdır.")]
        public string? Text { get; set; }

        [Display(Name = "Yıldız Sayısı")]
        [Range(1, 5, ErrorMessage = "Yıldız sayısı 1 ile 5 arasında olmalıdır.")]
        public byte StarCount { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [MaxLength(100, ErrorMessage = "Kullanıcı adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        public string? UserName { get; set; }
    }

    public class ProductCommentCreateDTO
    {
        [Display(Name = "Yorum Metni")]
        [MaxLength(500, ErrorMessage = "Yorum metni en fazla 500 karakter uzunluğunda olmalıdır.")]
        public string? Text { get; set; }

        [Display(Name = "Yıldız Sayısı")]
        [Range(1, 5, ErrorMessage = "Yıldız sayısı 1 ile 5 arasında olmalıdır.")]
        public byte StarCount { get; set; }

        [Display(Name = "Kullanıcı ID")]
        public int? UserId { get; set; }

        [Display(Name = "Ürün ID")]
        [Required(ErrorMessage = "Ürün ID alanı gereklidir.")]
        public int ProductId { get; set; }
    }
}
