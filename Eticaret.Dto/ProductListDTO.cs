
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class ProductListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}



