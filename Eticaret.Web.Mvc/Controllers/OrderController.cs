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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    // [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderService;
        private readonly IOrderItemRepository _orderItemService;
        private readonly ICartItemRepository _cartItemService;

        public OrderController(IOrderRepository orderService,
                            IOrderItemRepository orderItemService,
                            ICartItemRepository cartItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _cartItemService = cartItemService;
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel item)
        {
            if (!string.IsNullOrEmpty(item.Address))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null && int.TryParse(userId, out int Id))
                {
                    var cartitems = _cartItemService.GetDb()
                                                .Where(c => c.UserId == Id)
                                                .Include(c => c.ProductFk)
                                                .ToList();
                    List<OrderItem> orderList = new();
                    Order order = new()
                    {
                        Address = item.Address,
                        UserId = Id
                    };
                    _orderService.Add(order);
                    foreach (var cart in cartitems)
                    {
                        OrderItem orderItem = new()
                        {
                            Quantity = cart.Quantity,
                            UnitPrice = cart.ProductFk!.Price,
                            ProductId = cart.ProductId,
                            OrderId = order.Id,
                            SellerId = cart.ProductFk.SellerId
                        };
                        _orderItemService.Add(orderItem);
                        _cartItemService.Delete(cart);
                    }
                    return RedirectToRoute(new
                    {
                        action = nameof(Details),
                        orderCode = order.OrderCode
                    });
                }

            }
            return RedirectToAction(nameof(CartController.Edit), nameof(CartController).Replace("Controller", string.Empty));
        }

        public IActionResult Details(string orderCode)
        {
            var order = _orderService.GetDb()
                            .Include(o => o.OrderItems)
                            .ThenInclude(o => o.ProductFk)
                            .ThenInclude(o => o.SellerFk)
                            .FirstOrDefault(o => o.OrderCode == orderCode);

            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction(nameof(Index), "Home");
        }

    }
}