using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class AdminCategoryListDTO
    {
        [Required(ErrorMessage = "Kategori ID'si gereklidir.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Kategori rengi gereklidir.")]
        public string? Color { get; set; } = null!;

        [Required(ErrorMessage = "Kategori CSS sınıfı gereklidir.")]
        public string? Css { get; set; } = null!;

        [Required(ErrorMessage = "Oluşturma tarihi gereklidir.")]
        public string CreatedAt { get; set; } = null!;

        public int ProductCount { get; set; }
    }

    public class AdminCategoryUpdateDTO
    {
        [Required(ErrorMessage = "Kategori ID'si gereklidir.")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? Css { get; set; }
    }

    public class AdminCategoryCreateDTO
    {
        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        public string Name { get; set; } = null!;

        public string? Color { get; set; }

        public string? Css { get; set; }
    }
}
