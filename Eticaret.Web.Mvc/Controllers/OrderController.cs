using System.Text.Json;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private HttpClient _httpClient;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Address)
        {
            if (ModelState.IsValid)
            {
                OrderDTO order = new() { Address = Address };

                var response = await _httpClient.PostAsJsonAsync("Order", order);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);
                    var orderCode = responseData?["orderCode"];

                    return RedirectToRoute(new
                    {
                        action = nameof(Details),
                        orderCode = orderCode ?? ""
                    });
                }

                TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";
            }

            ModelState.AddModelError("", "Hata Oluştu!");

            return RedirectToRoute(new
            {
                action = nameof(CartController.Edit),
                controller = nameof(CartController).Replace("Controller", string.Empty)
            });
        }

        public async Task<IActionResult> Details(string orderCode)
        {
            using (var response = await _httpClient.GetAsync($"Order/{orderCode}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadFromJsonAsync<OrderDetailDTO>();

                    if (orders != null) return View(orders);
                }

                TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";
            }
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}