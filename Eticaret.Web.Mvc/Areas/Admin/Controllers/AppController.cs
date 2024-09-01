using Microsoft.AspNetCore.Mvc;
using Eticaret.Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin), Authorize(Roles = Roles.Admin)]
    public class AppController : Controller
    {
        public void ViewBagMessage(string message)
        {
            ViewBag.ErrorMessage = $"Error: {message}";
        }
        public void TempDataMessage(string message)
        {
            TempData["ErrorMessage"] = $"Error: {message}";
        }
    }
}