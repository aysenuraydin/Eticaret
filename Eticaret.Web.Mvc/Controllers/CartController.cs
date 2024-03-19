using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    // [Authorize]
    public class CartController : Controller
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartController(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public IActionResult AddProduct(int id)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId != null && int.TryParse(userId.Value, out int user))
            {
                var cartItem = _cartItemRepository.GetAll()
                                .FirstOrDefault(c => c.ProductId == id && c.UserId == user);

                if (cartItem == null)
                {
                    CartItem İtem = new()
                    {
                        Quantity = 1,
                        UserId = user,
                        ProductId = id
                    };
                    _cartItemRepository.Add(İtem);
                }
                else
                {
                    cartItem.Quantity += 1;
                    _cartItemRepository.Update(cartItem);
                }
                return RedirectToAction(nameof(Edit));


            }
            return RedirectToAction(nameof(Index), "home");
        }
        public IActionResult Edit()
        {
            var cartItems = _cartItemRepository.GetDb()
                                            .Include(c => c.ProductFk)
                                            .ToList();
            var cartOrder = new OrderViewModel()
            {
                CartItems = cartItems
            };
            return View(cartOrder);
        }
        [HttpPost]
        public IActionResult Edit(CartItem item)
        {
            var cartItem = _cartItemRepository.Find(item.Id);
            if (cartItem != null)
            {
                cartItem.Quantity = item.Quantity;
                _cartItemRepository.Update(cartItem);
            }

            var cartItems = _cartItemRepository.GetDb()
                                            .Include(c => c.ProductFk)
                                            .ToList();
            var cartOrder = new OrderViewModel()
            {
                CartItems = cartItems
            };
            return View(cartOrder);
        }
        [HttpPost]
        public IActionResult Delete(CartItem item)
        {
            var cartItem = _cartItemRepository.GetAll()
                                 .FirstOrDefault(i => i.Id == item.Id);
            if (cartItem != null)
            {
                _cartItemRepository.Delete(cartItem);
            }
            return RedirectToAction(nameof(Edit), "Cart");
        }
    }
}
