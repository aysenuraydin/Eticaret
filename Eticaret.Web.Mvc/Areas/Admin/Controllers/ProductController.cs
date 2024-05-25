using System.Text;
using System.Text.Json;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }

        public async Task<IActionResult> List()
        {
            using (var response = await _httpClient.GetAsync("AdminProduct"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var products = await response.Content.ReadFromJsonAsync<List<AdminProductListDTO>>() ?? new List<AdminProductListDTO>();
                    return View(products);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                    return View("Error");
                }
            }
        }
        public async Task<IActionResult> Approve(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminProduct/{id}"))
            {
                AdminProductListDTO product = await response.Content.ReadFromJsonAsync<AdminProductListDTO>() ?? new();
                return View(product);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(AdminProductListDTO product)
        {
            try
            {
                var json = JsonSerializer.Serialize(product);

                var response = await _httpClient.PutAsync($"AdminProduct/{product.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var updateBook = await response.Content.ReadFromJsonAsync<AdminProductListDTO>();
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();

                    ViewBag.Error = error;
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminProduct/{id}"))
            {
                AdminProductListDTO product = await response.Content.ReadFromJsonAsync<AdminProductListDTO>() ?? new();
                return View(product);
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"AdminProduct/{id}");

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(List));
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
