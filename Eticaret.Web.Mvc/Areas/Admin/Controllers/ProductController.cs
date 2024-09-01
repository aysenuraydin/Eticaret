using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    public class ProductController : AppController
    {
        private readonly HttpClient _httpClient;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
        }

        public async Task<IActionResult> List()
        {
            if (TempData["ErrorMessage"] != null) ViewBagMessage(TempData["ErrorMessage"].ToString());

            using (var response = await _httpClient.GetAsync("AdminProduct"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var products = await response.Content.ReadFromJsonAsync<List<AdminProductListDTO>>();

                    return View(products);
                }

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }

        public async Task<IActionResult> Approve(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminProduct/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    AdminProductListDTO product = await response.Content.ReadFromJsonAsync<AdminProductListDTO>() ?? new();

                    return View(product);
                }

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(AdminProductListDTO product)
        {
            var response = await _httpClient.PutAsJsonAsync($"AdminProduct/{product.Id}", product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(List));
            }

            ViewBagMessage(response.ReasonPhrase);

            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminProduct/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    AdminProductListDTO product = await response.Content.ReadFromJsonAsync<AdminProductListDTO>() ?? new();

                    return View(product);
                }

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"AdminProduct/{id}");

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(List));

            TempDataMessage(response.ReasonPhrase);

            return RedirectToAction(nameof(List));
        }
    }
}
