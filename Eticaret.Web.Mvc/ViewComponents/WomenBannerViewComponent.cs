using Eticaret.Application.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class WomenBannerViewComponent : ViewComponent
    {
        private readonly IProductRepository _productService;

        public WomenBannerViewComponent(IProductRepository productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var p = await _productService.GetAllAsync();
            var product = p.Where(p => p.IsConfirmed && p.Enabled).OrderByDescending(p => p.CreatedAt).Take(4);
            return View(product);
        }

    }
}

