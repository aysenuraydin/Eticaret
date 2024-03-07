using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    public class TemplateController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }

        public IActionResult blog()
        {
            return View();
        }
        public IActionResult blogdetail()
        {
            return View();
        }

        public IActionResult categories()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult product()
        {
            return View();
        }

        public IActionResult productdetail()
        {
            return View();
        }

        public IActionResult shopingcart()
        {
            return View();
        }

        public IActionResult single()
        {
            return View();
        }

    }
}