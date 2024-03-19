
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class ProductImage : BaseEntity
    {
        [MaxLength(250), MinLength(10), DataType(DataType.Url)]
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ProductId { get; set; }

        #region Navigation Properties
        public Product? ProductFk { get; set; }
        #endregion

    }
}
