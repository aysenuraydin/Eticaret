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
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepository _sellerService;

        public SellerController(ISellerRepository sellerService)
        {
            _sellerService = sellerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seller = await _sellerService.GetAllAsync();

            var sellerDTO = new List<SellerDTO>();

            foreach (var item in seller)
            {
                sellerDTO.Add(SelleroDTO(item));
            }

            return Ok(sellerDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _sellerService.FindAsync(id);

            if (item == null)
            {
                return NotFound(); // 404
            }
            return Ok(SelleroDTO(item)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Seller seller)
        {
            await _sellerService.AddAsync(seller);
            return CreatedAtAction(nameof(Get), new { id = seller.Id }, SelleroDTO(seller));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            var item = await _sellerService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _sellerService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            var item = await _sellerService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _sellerService.DeleteAsync(item);
            return NoContent();
        }
        private static SellerDTO SelleroDTO(Seller seller)
        {
            return new SellerDTO
            {
                Id = seller.Id,
                Email = seller.Email,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Password = seller.Password,
                Enabled = seller.Enabled,
                CreatedAt = seller.CreatedAt,
                RoleId = seller.RoleId
            };
        }
    }
}











