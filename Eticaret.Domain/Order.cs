
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class Order : BaseEntity
    {
        [MinLength(2)]
        public string? OrderCode { get; set; }
        [MaxLength(250), MinLength(2)]
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //[ForeignKey("User")]
        public int UserId { get; set; }

        #region Navigation Properties
        public User? UserFk { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
        #endregion

    }
}
