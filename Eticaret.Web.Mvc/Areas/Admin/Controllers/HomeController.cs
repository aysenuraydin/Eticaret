using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryService;

        public HomeController(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var category = _categoryService.GetDb()
                                        .Include(c => c.Products)
                                        .ToList();
            return View(category);
        }
    }
}

