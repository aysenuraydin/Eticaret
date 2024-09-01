using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class CartController : AppController
    {
        private readonly HttpClient _httpClient;

        public CartController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
        }

        public async Task<IActionResult> AddProduct(int id)
        {
            var response = await _httpClient.PostAsync($"Cart/{id}", null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Edit));
            }

            TempDataMessage(response.ReasonPhrase);

            return RedirectToAction(nameof(Edit));
        }

        public async Task<IActionResult> Edit()
        {
            if (TempData["ErrorMessage"] != null) ViewBagMessage(TempData["ErrorMessage"].ToString().ToString());

            using (var response = await _httpClient.GetAsync($"Cart"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var carts = await response.Content.ReadFromJsonAsync<List<CartItemListDTO>>() ?? new();

                    return View(carts);
                }

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CartItemListDTO item)
        {
            if (!ModelState.IsValid) return View(item);

            CartItemUpdateDTO cartItem = new() { Id = item.Id, Quantity = item.Quantity };

            var response = await _httpClient.PutAsJsonAsync($"Cart/{item.Id}", cartItem);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Edit));
            }

            ViewBagMessage(response.ReasonPhrase);
            ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Cart/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempDataMessage(response.ReasonPhrase);
            }

            return RedirectToAction(nameof(Edit));
        }
    }
}
