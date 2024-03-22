
namespace Eticaret.Models.DTO
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
    }
}