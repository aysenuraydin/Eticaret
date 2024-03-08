using System.ComponentModel.DataAnnotations;
using Eticaret.Domain.Abstract;

namespace Eticaret.Domain
{
    public class Seller : User
    {
        [MaxLength(250), MinLength(10)]
        public string? Adress { get; set; }
        public long CallNumber { get; set; }

        public List<Product> Products { get; set; } = new();
        public List<ProductImage> ProductImages { get; set; } = new();

    }
}