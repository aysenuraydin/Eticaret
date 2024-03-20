using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderService;

        public ProfileController(
            IUserRepository userRepository,
            IOrderRepository orderService)
        {
            _userRepository = userRepository;
            _orderService = orderService;
        }

        public IActionResult Details()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null && int.TryParse(userId, out int Id))
            {
                var user = _userRepository.GetDb()
                                        .Include(u => u.RoleFk)
                                        .Include(u => u.Orders)
                                        .Include(u => u.CartItems)
                                        .Include(u => u.ProductComments)
                                        .FirstOrDefault();
                if (user != null)
                {
                    return View(user);
                }
            }
            return View();
        }

        public IActionResult Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null && int.TryParse(userId, out int Id))
            {
                var user = _userRepository.GetDb()
                                        .Include(u => u.RoleFk)
                                        .Include(u => u.Orders)
                                        .Include(u => u.CartItems)
                                        .Include(u => u.ProductComments)
                                        .FirstOrDefault();
                if (user != null)
                {
                    RegisterViewModel editUser = new()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password,
                        ConfirmPassword = user.Password
                    };
                    return View(editUser);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var editUser = _userRepository.Find(int.Parse(userId!));

                    editUser.FirstName = user.FirstName;
                    editUser.LastName = user.LastName;
                    editUser.Email = user.Email;
                    editUser.Password = user.Password;

                    _userRepository.Update(editUser);
                    return RedirectToAction(nameof(Details));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(user);
        }
        public IActionResult MyOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null && int.TryParse(userId, out int Id))
            {
                try
                {
                    var order = _orderService.GetDb()
                            .Include(o => o.OrderItems)
                            .ThenInclude(o => o.ProductFk)
                            .ThenInclude(o => o.ProductImages)
                            .ThenInclude(o => o.SellerFk)
                            .Where(o => o.UserId == Id)
                            .OrderByDescending(o => o.CreatedAt)
                            .ToList();

                    return View(order);
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
        }
    }
}