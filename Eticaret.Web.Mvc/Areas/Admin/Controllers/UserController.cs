
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userService;
        private readonly IRoleRepository _roleService;
        private readonly ISellerRepository _sellerService;

        public UserController(IUserRepository userService, IRoleRepository roleService, ISellerRepository sellerervice)
        {
            _userService = userService;
            _roleService = roleService;
            _sellerService = sellerervice;
        }

        public IActionResult List()
        {
            var user = _userService.GetDb()
                            .Include(u => u.RoleFk)
                            .Include(u => u.CartItems)
                            .Include(u => u.ProductComments)
                            .Include(u => u.Orders)
                            .OrderBy(u => u.Enabled)
                            .Where(u => u.RoleId != 3)
                            .ToList();

            return View(user);
        }
        public IActionResult Approve(int id)
        {
            var user = _userService.GetDb()
                            .Include(u => u.RoleFk)
                            .Include(u => u.CartItems)
                            .Include(u => u.ProductComments)
                            .Include(u => u.Orders)
                            .FirstOrDefault(p => p.Id == id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Approve(User user)
        {
            try
            {
                _userService.Update(user);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View(user);
            }
        }



        public IActionResult Delete(int id)
        {
            var user = _userService.GetDb()
                            .Include(u => u.RoleFk)
                            .Include(u => u.CartItems)
                            .Include(u => u.ProductComments)
                            .Include(u => u.Orders)
                           .FirstOrDefault(p => p.Id == id);

            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(int id, User comment)
        {
            try
            {
                _userService.Delete(comment);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View(id);
            }

        }
    }
}
















