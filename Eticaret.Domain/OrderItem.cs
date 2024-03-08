
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class OrderItem : BaseEntity
    {
        [MinLength(1)]
        public byte Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        #region Navigation Properties
        public Product? ProductFk { get; set; }
        public Order? OrderFk { get; set; }
        #endregion
    }
}
