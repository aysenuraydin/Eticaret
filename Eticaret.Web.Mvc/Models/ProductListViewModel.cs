using Eticaret.Dto;

namespace Eticaret.Web.Mvc.Models
{
    public class ProductListViewModel
    {
        public List<ProductListDTO>? ProductList { get; set; } = new();
        public List<CategoryListDTO>? Categories { get; set; } = new();
    }
}


