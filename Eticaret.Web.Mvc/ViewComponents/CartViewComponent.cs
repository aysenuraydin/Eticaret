using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartViewComponent(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId != null && int.TryParse(userId.Value, out int user))
            {
                var cartItems = await _cartItemRepository.GetDb()
                                          .Where(c => c.UserId == user)
                                          .Include(u => u.ProductFk!)
                                          .ThenInclude(u => u.ProductImages)
                                          .ToListAsync();


                return View(cartItems);
            }
            else
            {
                return View(new List<CartItem>());
            }
        }

    }
}

