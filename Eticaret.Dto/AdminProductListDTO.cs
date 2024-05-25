
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class AdminProductListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public List<string?> ImageUrlList { get; set; } = new()!;
        public string Details { get; set; } = null!;
        public byte StockAmount { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryColor { get; set; }
        public string? CreatedAt { get; set; }
        public bool Enabled { get; set; }
        public bool IsConfirmed { get; set; }
        public string? SellerName { get; set; }
        public int CommentCount { get; set; }
        public int OrderCount { get; set; }
        public int CartCount { get; set; }
    }
    public class AdminProductUpdateDTO
    {
        public int Id { get; set; }
        public bool IsConfirmed { get; set; }
    }

}



