using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Controllers
{
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