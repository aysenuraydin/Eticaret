using System.Security.Claims;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Eticaret.Api.Controllers
{
    [Authorize]
    public class OrderController : AppController
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
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                var orders = await _orderService.GetAllOrdersItemsAsync(userId);
                if (orders == null) return NotFound();
                var orderDtos = orders.Select(i => OrderListToDTO(i)).ToList();
                return Ok(orderDtos);
            }
            return BadRequest();
        }
        [HttpGet("{orderCode}")]
        public async Task<IActionResult> GetOrder(string orderCode)
        {
            var order = await _orderService.GetOrdersItemsAsync(orderCode);
            if (order == null) return NotFound();
            return Ok(OrderListToDTO(order));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO entity)
        {
            try
            {
                if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
                {
                    var cartitems = await _cartItemService.GetIdAllIncludeFilterAsync(
                                                c => c.UserId == userId,
                                                c => c.ProductFk!
                                                );
                    List<OrderItem> orderList = new();
                    Order order = new()
                    {
                        Address = entity.Address,
                        UserId = userId
                    };
                    await _orderService.AddAsync(order);
                    foreach (var cart in cartitems)
                    {
                        OrderItem orderItem = new()
                        {
                            Quantity = cart.Quantity,
                            UnitPrice = cart.ProductFk!.Price,
                            ProductId = cart.ProductId,
                            OrderId = order.Id,
                            UserId = cart.ProductFk.UserId
                        };
                        await _orderItemService.AddAsync(orderItem);
                        await _cartItemService.DeleteAsync(cart);
                    }
                    return Ok(new { order.OrderCode });
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        private static OrderDetailDTO OrderListToDTO(Order o)
        {
            return new OrderDetailDTO
            {
                Address = o.Address,
                OrderCode = o.OrderCode,
                CreatedAt = o.CreatedAt,
                OrderItems = o.OrderItems.Select(i =>
                        new CartItemListDTO()
                        {
                            Id = i.Id,
                            ProductImages = i.ProductFk.ProductImages[0].Url,
                            ProductName = i.ProductFk.Name,
                            ProductId = i.Id,
                            ProductPrice = i.ProductFk.Price,
                            Quantity = i.Quantity,
                        }
                    ).ToList(),
            };
        }

    }
}
