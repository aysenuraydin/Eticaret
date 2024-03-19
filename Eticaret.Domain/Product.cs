
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class Product : BaseEntity
    {
        [MaxLength(100), MinLength(2)]
        public string? Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [MaxLength(100), MinLength(2)]
        public string? Details { get; set; }
        public byte StockAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Enabled { get; set; } = true;
        public int SellerId { get; set; }
        public int CategoryId { get; set; }

        #region Navigation Properties
        public Seller? SellerFk { get; set; }
        public Category? CategoryFk { get; set; }

        public List<ProductComment> ProductComments { get; set; } = new();
        public List<OrderItem> OrderItems { get; set; } = new();
        public List<CartItem> CartItems { get; set; } = new();

        #endregion


    }
}