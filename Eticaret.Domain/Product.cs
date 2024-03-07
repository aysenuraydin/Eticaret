
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Details { get; set; }
        public byte StockAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Enabled { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }

        #region Navigation Properties
        public Seller? SellerFk { get; set; }
        public Category? CategoryFk { get; set; }
        #endregion


    }
}