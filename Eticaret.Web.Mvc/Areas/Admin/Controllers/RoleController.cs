using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleService;
        private readonly IUserRepository _userService;

        public RoleController(IRoleRepository roleService, IUserRepository userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var role = _roleService.GetDb()
                            .Include(r => r.Users)
                            .ToList();

            return View(role);
        }

        public IActionResult Admin(int id)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            if (user == null) BadRequest();
            else
            {
                user.RoleId = 3;
                _userService.Update(user);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Buyer(int id)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            if (user == null) BadRequest();
            else
            {
                user.RoleId = 2;
                _userService.Update(user);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Seller(int id)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            try
            {
                if (user != null)
                {
                    Seller seller = new Seller()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password,
                        Enabled = true,
                        CreatedAt = user.CreatedAt,
                        RoleId = 1,
                        RoleFk = user.RoleFk,
                        CartItems = user.CartItems,
                        ProductComments = user.ProductComments,
                        Orders = user.Orders
                    };
                    _userService.Update(seller);
                    _userService.Delete(user);
                }
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View(user);
            }

        }
    }
}



