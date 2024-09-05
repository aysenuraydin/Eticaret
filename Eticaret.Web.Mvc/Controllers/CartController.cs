using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Eticaret.Web.Mvc.Models.ConfigModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class CartController : AppController
    {
        private readonly HttpClient _httpClient;
        private readonly FileDownloadConfigModels? _options;

        public CartController(IHttpClientFactory httpClientFactory, IOptions<FileDownloadConfigModels> options)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
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
            ViewBag.HostAdress = _options.BaseUrl;
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
