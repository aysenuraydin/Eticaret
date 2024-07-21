using System.Security.Claims;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IProductImageRepository _productImageRepo;
        public CartController(ICartItemRepository cartItemRepo, IProductImageRepository productImageRepo)
        {
            _cartItemRepo = cartItemRepo;
            _productImageRepo = productImageRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCartItems()
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                var products = (await _cartItemRepo.GetIdAllIncludeFilterAsync(
                                      i => i.UserId == userId,
                                      i => i.ProductFk!
                                      ))
                                      .Select(p => CartsToDTO(p))
                                      .ToList();

                foreach (var product in products)
                {
                    var image = await _productImageRepo.GetAsync(i => i.ProductId == product.ProductId);
                    product.ProductImages = image?.Url;
                }

                return Ok(products);
            }

            return NotFound();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetCartItem(int productId)
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                var product = (await _cartItemRepo.GetIdAllIncludeFilterAsync(
                                      i => i.UserId == userId && i.ProductId == productId,
                                      i => i.ProductFk!
                                      ))
                                      .FirstOrDefault();

                if (product == null) NotFound();

                var prd = CartsToDTO(product!);
                prd.ProductImages = (await _productImageRepo.GetAsync(i => i.ProductId == prd.ProductId))?.Url;

                return Ok(prd);
            }

            return NotFound(userId);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateCartItem(int id)
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                var cartItem = (await _cartItemRepo.GetIdAllIncludeFilterAsync(
                                      c => c.ProductId == id && c.UserId == userId
                                     )).FirstOrDefault();

                if (cartItem == null)
                {
                    CartItem item = new()
                    {
                        Quantity = 1,
                        UserId = userId,
                        ProductId = id
                    };
                    await _cartItemRepo.AddAsync(item);
                }
                else
                {
                    cartItem.Quantity += 1;
                    await _cartItemRepo.UpdateAsync(cartItem);
                }

                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, CartItemUpdateDTO item)
        {
            if (id != item.Id) return BadRequest();

            try
            {
                var cartItem = await _cartItemRepo.FindAsync(item.Id);

                if (cartItem != null)
                {
                    cartItem.Quantity = item.Quantity;
                    await _cartItemRepo.UpdateAsync(cartItem);

                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Hata Oluştu: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int? id)
        {
            if (id == null) return NotFound();

            var prd = await _cartItemRepo.GetAsync(i => i.Id == id);

            if (prd == null) return NotFound();

            try
            {
                await _cartItemRepo.DeleteAsync(prd);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        private static CartItemListDTO CartsToDTO(CartItem c)
        {
            CartItemListDTO cart = new()
            {
                Id = c.Id,
                ProductName = c.ProductFk?.Name,
                ProductId = c.ProductFk!.Id,
                ProductPrice = c.ProductFk.Price,
                Quantity = c.Quantity,
            };

            return cart;
        }
    }
}

