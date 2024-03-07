
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? IconCssClass { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}