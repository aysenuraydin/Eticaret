using System.ComponentModel.DataAnnotations;
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class OrderDetailDTO
    {
        public string? Address { get; set; }
        public List<CartItemListDTO> OrderItems { get; set; } = new();
        public string? OrderCode { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
