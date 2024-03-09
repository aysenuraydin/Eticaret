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
        public IActionResult blog()
        {
            return View();
        }
        public IActionResult blogdetail()
        {
            return View();
        }
    }
}