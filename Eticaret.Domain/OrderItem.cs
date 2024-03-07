
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class OrderItem : BaseEntity
    {
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        #region Navigation Properties
        public User? UserFk { get; set; }
        public Product? ProductFk { get; set; }
        public Order? OrderFk { get; set; }
        #endregion
    }
}
