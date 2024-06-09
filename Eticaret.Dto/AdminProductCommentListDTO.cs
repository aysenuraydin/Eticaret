using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class AdminProductCommentListDTO
    {
        [Required(ErrorMessage = "Yorum ID'si gereklidir.")]
        public int Id { get; set; }

        public string? Text { get; set; }

        [Required(ErrorMessage = "Yıldız sayısı gereklidir.")]
        public byte StarCount { get; set; }

        public bool IsConfirmed { get; set; } = false;

        [Required(ErrorMessage = "Oluşturma tarihi gereklidir.")]
        public string? CreatedAt { get; set; }

        public string? UserName { get; set; }

        public string? ProductName { get; set; }
    }

    public class AdminProductCommentUpdateDTO
    {
        [Required(ErrorMessage = "Yorum ID'si gereklidir.")]
        public int Id { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
