
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class Cart : BaseEntity
    {

        #region Navigation Propertiesnew();
        public List<CartItem> CartItems { get; set; } = new();

        #endregion

    }
}