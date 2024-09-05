using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Eticaret.Web.Mvc.Models;
using Eticaret.Web.Mvc.Models.ConfigModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class ProfileController : AppController
    {
        private readonly HttpClient _httpClient;

        private readonly FileDownloadConfigModels? _options;

        public ProfileController(IHttpClientFactory httpClientFactory, IOptions<FileDownloadConfigModels> options)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }


        public async Task<IActionResult> Details()
        {
            using (var response = await _httpClient.GetAsync("Profile"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new AdminUserListDTO() ?? new AdminUserListDTO();

                    return View(user);
                }

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }

        public async Task<IActionResult> Edit()
        {
            using (var response = await _httpClient.GetAsync("Profile"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new AdminUserListDTO() ?? new AdminUserListDTO();

                    if (user != null)
                    {
                        RegisterViewModel editUser = new()
                        {
                            FirstName = user.FirstName!,
                            LastName = user.LastName!,
                            Email = user.Email!
                        };

                        return View(editUser);
                    }
                }

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegisterViewModel user)
        {
            if (!ModelState.IsValid) return View(user);

            var u = new UserUpdateDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email,
            };

            var response = await _httpClient.PutAsJsonAsync($"Profile", u);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Details));
            }

            ViewBagMessage(response.ReasonPhrase);

            return View(user);
        }

        public async Task<IActionResult> MyOrders()
        {
            ViewBag.HostAdress = _options.BaseUrl;
            using (var response = await _httpClient.GetAsync($"Order"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadFromJsonAsync<List<OrderDetailDTO>>();

                    if (orders != null) return View(orders);

                    ViewBagMessage(response.ReasonPhrase);
                }
            }

            return View();
        }
    }
}



