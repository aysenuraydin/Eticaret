
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class ProductDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Details { get; set; } = null!;
        public byte StockAmount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string SellerName { get; set; } = null!;

        public List<Comment> ProductComments { get; set; } = new();
        public List<Images> ProductImagesUrl { get; set; } = new();
    }
    public class Comment
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public byte StarCount { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public string CreatedAt { get; set; } = string.Empty;
        public string? UserName { get; set; }
    }
    public class Images
    {
        public int Id { get; set; }
        public string? Url { get; set; }
    }

}



