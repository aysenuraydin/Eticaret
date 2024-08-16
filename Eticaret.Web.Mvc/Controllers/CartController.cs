using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly HttpClient _httpClient;

        public CartController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IActionResult> AddProduct(int id)
        {
            var response = await _httpClient.PostAsync($"Cart/{id}", null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Edit));
            }

            TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";

            return RedirectToAction(nameof(Edit));
        }

        public async Task<IActionResult> Edit()
        {
            if (TempData["ErrorMessage"] != null) ViewBag.ErrorMessage = TempData["ErrorMessage"];

            using (var response = await _httpClient.GetAsync($"Cart"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var carts = await response.Content.ReadFromJsonAsync<List<CartItemListDTO>>() ?? new();

                    return View(carts);
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
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

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
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
                TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";
            }

            return RedirectToAction(nameof(Edit));
        }
    }
}
