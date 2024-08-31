using Eticaret.Domain;

namespace Eticaret.Web.Mvc.Models
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Details { get; set; } = null!;

        public byte StockAmount { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsConfirmed { get; set; } = false;

        public bool Enabled { get; set; } = false;
        public int CategoryId { get; set; }
        public int SellerIdId { get; set; }

        public List<ProductComment> ProductComments { get; set; } = new();
        public List<OrderItem> OrderItems { get; set; } = new();
        public List<CartItem> CartItems { get; set; } = new();

    }
}