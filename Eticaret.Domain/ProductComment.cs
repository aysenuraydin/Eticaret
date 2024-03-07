
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class ProductComment : BaseEntity
    {

        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string? Text { get; set; }
        public byte StarCount { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}