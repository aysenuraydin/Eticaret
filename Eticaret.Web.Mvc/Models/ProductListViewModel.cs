using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Domain;

namespace Eticaret.Web.Mvc.Models
{
    public class ProductListViewModel
    {
        public List<Product>? ProductList { get; set; } = new();
        public string? Search { get; set; }
    }
}


