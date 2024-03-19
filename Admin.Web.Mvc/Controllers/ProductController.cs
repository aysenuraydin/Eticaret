using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Admin.Web.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Delete()
        {
            return View();
        }
    }
}
