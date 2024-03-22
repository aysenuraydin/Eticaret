
namespace Eticaret.Models.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int SellerId { get; set; }
    }

}