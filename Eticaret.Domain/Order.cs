
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class Order : BaseEntity
    {
        public string? OrderCode { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        #region Navigation Properties
        public User? UserFk { get; set; }
        #endregion

    }
}
