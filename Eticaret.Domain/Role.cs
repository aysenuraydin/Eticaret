
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class Role : BaseEntity
    {
        [MaxLength(50), MinLength(2)]
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<User> Users { get; set; } = new();

    }
}