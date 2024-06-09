using System.ComponentModel.DataAnnotations;

namespace Eticaret.Dto
{
    public class CartItemListDTO
    {
        public int Id { get; set; }
        public string? ProductImages { get; set; }
        public string? ProductName { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public byte Quantity { get; set; }
    }
}


