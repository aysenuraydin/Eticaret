
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class CartItem : BaseEntity
    {

        public byte Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        #region Navigation Properties
        public User? UserFk { get; set; }
        public Product? ProductFk { get; set; }
        #endregion

    }
}