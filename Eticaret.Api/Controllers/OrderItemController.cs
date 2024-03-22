using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Models.DTO;
using Eticaret.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemService;

        public OrderItemController(
        IOrderItemRepository orderItemService)
        {
            _orderItemService = orderItemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _orderItemService.GetAllAsync();

            var OrderItemDTO = new List<OrderItemDTO>();

            foreach (var o in comments)
            {
                OrderItemDTO.Add(OrderItemToDTO(o));
            }

            return Ok(OrderItemDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orderItem = await _orderItemService.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound(); // 404
            }
            return Ok(OrderItemToDTO(orderItem)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(OrderItem orderItem)
        {
            await _orderItemService.AddAsync(orderItem);
            return CreatedAtAction(nameof(Get), new { id = orderItem.Id }, OrderItemToDTO(orderItem));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            var o = await _orderItemService.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            await _orderItemService.UpdateAsync(o);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            var o = await _orderItemService.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            await _orderItemService.DeleteAsync(o);
            return NoContent();
        }
        private static OrderItemDTO OrderItemToDTO(OrderItem o)
        {
            return new OrderItemDTO
            {
                Id = o.Id,
                Quantity = o.Quantity,
                UnitPrice = o.UnitPrice,
                CreatedAt = o.CreatedAt,
                ProductId = o.ProductId,
                OrderId = o.OrderId,
                SellerId = o.SellerId
            };
        }
    }
}





