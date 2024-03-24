using Eticaret.Application.Abstract;
using Eticaret.Persistence.Ef;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class RelatedProductsViewComponent : ViewComponent
    {
        private IProductRepository _repository;//şimdilik bu şekilde

        public RelatedProductsViewComponent(IProductRepository repo)
        {
            _repository = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var p = await _repository.GetIdAllIncludeFilterAsync(
                p => p.IsConfirmed && p.Enabled,
                p => p.ProductImages
            );
            //search den al
            return View(p);
        }
    }

}


