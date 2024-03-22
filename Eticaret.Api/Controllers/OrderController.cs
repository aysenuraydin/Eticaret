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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderService;

        public OrderController(IOrderRepository orderervice)
        {
            _orderService = orderervice;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Order = await _orderService.GetAllAsync();

            var OrderDTO = new List<OrderDTO>();

            foreach (var o in Order)
            {
                OrderDTO.Add(OrderoDTO(o));
            }

            return Ok(OrderDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var o = await _orderService.FindAsync(id);

            if (o == null)
            {
                return NotFound(); // 404
            }
            return Ok(OrderoDTO(o)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Order order)
        {
            await _orderService.AddAsync(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, OrderoDTO(order));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var o = await _orderService.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            await _orderService.UpdateAsync(o);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var o = await _orderService.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            await _orderService.DeleteAsync(o);
            return NoContent();
        }
        private static OrderDTO OrderoDTO(Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                OrderCode = order.OrderCode,
                Address = order.Address,
                CreatedAt = order.CreatedAt,
                UserId = order.UserId
            };
        }
    }
}











