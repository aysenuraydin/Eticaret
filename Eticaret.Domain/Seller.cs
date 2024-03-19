using System.ComponentModel.DataAnnotations;
using Eticaret.Domain.Abstract;

namespace Eticaret.Domain
{
    public class Seller : User
    {
        #region Navigation Properties
        [Display(Name = "Satıcı Ürünleri")]
        public List<Product> Products { get; set; } = new();

        [Display(Name = "Ürün Resimleri")]
        public List<ProductImage> ProductImages { get; set; } = new();
        [Display(Name = "Siparişleri")]
        public List<OrderItem> OrderItems { get; set; } = new();
        #endregion
    }
}