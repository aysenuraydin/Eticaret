using Eticaret.Domain;

namespace Eticaret.Web.Mvc.Models
{
    public class CommentProductViewModel
    {
        public Product? Product { get; set; } = new();
        public ProductComment? CommentProduct { get; set; } = new();
    }
}


