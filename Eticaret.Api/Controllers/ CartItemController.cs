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
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemService;

        public CartItemController(ICartItemRepository cartItemService)
        {
            _cartItemService = cartItemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cartItem = await _cartItemService.GetAllAsync();

            var cartItemDTO = new List<CartItemDTO>();

            foreach (var c in cartItem)
            {
                cartItemDTO.Add(cartItemToDTO(c));
            }

            return Ok(cartItemDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var c = await _cartItemService.FindAsync(id);

            if (c == null)
            {
                return NotFound(); // 404
            }
            return Ok(cartItemToDTO(c)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CartItem cartItem)
        {
            await _cartItemService.AddAsync(cartItem);
            return CreatedAtAction(nameof(Get), new { id = cartItem.Id }, cartItemToDTO(cartItem));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            var ctgry = await _cartItemService.FindAsync(id);

            if (ctgry == null)
            {
                return NotFound();
            }

            await _cartItemService.UpdateAsync(ctgry);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            var c = await _cartItemService.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            await _cartItemService.DeleteAsync(c);
            return NoContent();
        }
        private static CartItemDTO cartItemToDTO(CartItem c)
        {
            return new CartItemDTO
            {
                Id = c.Id,
                Quantity = c.Quantity,
                CreatedAt = c.CreatedAt,
                ProductId = c.ProductId,
                UserId = c.UserId
            };
        }
    }
}








