

using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly HttpClient _httpClient;
        public CartController(IHttpClientFactory httpClientFactory, ICartItemRepository cartItemRepository)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }

        public async Task<IActionResult> AddProduct(int id)
        {
            try
            {
                var response = await _httpClient.PostAsync($"Cart/{id}", null);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Edit), "Cart");
                }
                else
                {
                    ModelState.AddModelError("", "Ürün eklenirken bir hata oluştu.");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Bir hata oluştu!");
            }

            return RedirectToAction(nameof(Edit), "Cart");
        }

        public async Task<IActionResult> Edit()
        {
            using (var response = await _httpClient.GetAsync($"Cart"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var carts = await response.Content.ReadFromJsonAsync<List<CartItemListDTO>>() ?? new();
                    return View(carts);
                }
                return View(new List<CartItemListDTO>());

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CartItemListDTO item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonSerializer.Serialize(item);

                    var response = await _httpClient.PutAsync($"Cart/{item.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Edit), "Cart");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Hata Oluştu: {ex.Message}");
                }
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Cart/{id}");

                if (response.IsSuccessStatusCode)

                    return RedirectToAction(nameof(Edit), "Cart"); //!
                else
                    return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}
