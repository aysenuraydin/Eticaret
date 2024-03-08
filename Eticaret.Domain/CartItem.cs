
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class CartItem : BaseEntity
    {
        [MinLength(1)]
        public byte Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ProductId { get; set; }

        #region Navigation Properties
        public Product? ProductFk { get; set; }
        #endregion

    }
}