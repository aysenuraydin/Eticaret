
using System.Text;
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
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Address)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrderDTO order = new() { Address = Address };
                    var json = JsonSerializer.Serialize(order);

                    var response = await _httpClient.PostAsync("Order", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var responseData = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);
                        var orderCode = responseData["orderCode"];

                        return RedirectToRoute(new
                        {
                            action = nameof(Details),
                            orderCode = orderCode
                        });
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
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
                else
                {
                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                    return View("Error");
                }
            }
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}