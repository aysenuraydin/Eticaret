using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class CategoryListDTO
    {
        [Required(ErrorMessage = "Kategori ID'si gereklidir.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        public string Name { get; set; } = null!;
    }
}
