
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class Category : BaseEntity
    {
        [MaxLength(100), MinLength(2)]
        public string? Name { get; set; }
        [MaxLength(6), MinLength(3)]
        public string? Color { get; set; }
        [MaxLength(50), MinLength(2)]
        public string? IconCssClass { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Product> Products { get; set; } = new();

    }
}