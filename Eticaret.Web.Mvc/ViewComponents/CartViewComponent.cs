using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Eticaret.Web.Mvc.Models.ConfigModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Eticaret.Web.Mvc.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly FileDownloadConfigModels? _options;

        public CartViewComponent(IHttpClientFactory httpClientFactory, IOptions<FileDownloadConfigModels> options)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.HostAdress = _options.BaseUrl;
            try
            {
                using (var response = await _httpClient.GetAsync("Cart"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var products = await response.Content.ReadFromJsonAsync<List<CartItemListDTO>>();

                        return View(products);
                    }
                    return View(new List<CartItemListDTO>());
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine($"Request error: {httpRequestException.Message}");
                return View();
            }

        }

    }
}

