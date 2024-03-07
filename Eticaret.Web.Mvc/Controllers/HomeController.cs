using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Listing()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }

    }
}