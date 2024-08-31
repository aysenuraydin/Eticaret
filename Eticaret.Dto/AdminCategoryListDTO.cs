namespace Eticaret.Dto
{
    public class AdminCategoryListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Color { get; set; } = null!;
        public string? Css { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public int ProductCount { get; set; }
    }
}