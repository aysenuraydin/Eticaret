using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    public class ContactController : AppController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}