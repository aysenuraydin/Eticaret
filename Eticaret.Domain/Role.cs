
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class Role : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}