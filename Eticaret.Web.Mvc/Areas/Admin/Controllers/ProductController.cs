using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IActionResult> List()
        {
            try
            {
                using (var response = await _httpClient.GetAsync("AdminProduct"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var products = await response.Content.ReadFromJsonAsync<List<AdminProductListDTO>>();

                        return View(products);
                    }

                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return View(new List<AdminProductListDTO>());
        }

        public async Task<IActionResult> Approve(int id)
        {
            try
            {
                using (var response = await _httpClient.GetAsync($"AdminProduct/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        AdminProductListDTO product = await response.Content.ReadFromJsonAsync<AdminProductListDTO>() ?? new();

                        return View(product);
                    }

                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(AdminProductListDTO product)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"AdminProduct/{product.Id}", product);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(List));
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (var response = await _httpClient.GetAsync($"AdminProduct/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        AdminProductListDTO product = await response.Content.ReadFromJsonAsync<AdminProductListDTO>() ?? new();

                        return View(product);
                    }

                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"AdminProduct/{id}");

                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(List));

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return RedirectToAction(nameof(List)); //!
        }
    }
}
