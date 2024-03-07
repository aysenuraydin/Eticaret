
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class ProductImage : BaseEntity
    {

        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductId { get; set; }

        #region Navigation Properties
        public Product? ProductFk { get; set; }
        #endregion

    }
}
