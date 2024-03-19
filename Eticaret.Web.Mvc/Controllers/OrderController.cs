using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

    }
}