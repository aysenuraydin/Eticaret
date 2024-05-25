
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class ProductImageListDTO
    {
        public string? Url { get; set; }
        public string? CreatedAt { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
    }
    public class ProductImageCreateDTO
    {
        public string? Url { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
    }
}



