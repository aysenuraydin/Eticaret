
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class SellerProductListDTO : AdminProductListDTO
    {
        public int CategoryId { get; set; }
    }
    public class SellerProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Details { get; set; } = null!;
        public List<string> ImageList { get; set; } = new();
        public byte StockAmount { get; set; }
        public int CategoryId { get; set; }
        public bool Enabled { get; set; }
    }
    public class SellerProductCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Details { get; set; } = null!;
        public List<UpdateImage> ImageList { get; set; } = new();
        public byte StockAmount { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public bool Enabled { get; set; }
    }
    public class UpdateImage
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
    }
}

