using Eticaret.Application.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Admin.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryService;

        public HomeController(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var category = _categoryService.Find(1);

            return View(category);
        }
    }
}

