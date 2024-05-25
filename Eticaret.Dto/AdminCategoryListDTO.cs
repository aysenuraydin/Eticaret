
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class AdminCategoryListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Css { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public int ProductCount { get; set; }
    }
    public class AdminCategoryUpdateDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Css { get; set; } = null!;
    }
    public class AdminCategoryCreateDTO
    {
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? Css { get; set; }
    }
}
