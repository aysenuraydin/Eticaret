
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class ProductComment : BaseEntity
    {
        [MaxLength(500), MinLength(2)]
        public string? Text { get; set; }
        [MaxLength(5), MinLength(1)]
        public byte StarCount { get; set; }
        public bool IsConfirmed = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int ProductId { get; set; }

        #region Navigation Properties
        public User? UserFk { get; set; }
        public Product? ProductFk { get; set; }
        #endregion

    }
}