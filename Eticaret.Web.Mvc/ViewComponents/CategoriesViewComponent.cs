using Eticaret.Application.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryService;

        public CategoriesViewComponent(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _categoryService.GetAllAsync());
        }

    }
}

