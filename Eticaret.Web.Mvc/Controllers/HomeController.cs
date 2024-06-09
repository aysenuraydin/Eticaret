
using System.Diagnostics;
using System.Text.Json;
using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                using (var response = await _httpClient.GetAsync("Home"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var products = await response.Content.ReadFromJsonAsync<List<ProductListDTO>>();

                        return View(products); ;
                    }
                    else
                    {
                        ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                        return View(new List<ProductListDTO>());
                    }
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine($"Request error: {httpRequestException.Message}");
                return View(new List<ProductListDTO>());
            }
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public async Task<IActionResult> Listing(int? id, string? q)
        {
            var productList = new List<ProductListDTO>();
            var url = (id == null) ? $"Home" : $"Home/{id}";

            using (var response = await _httpClient.GetAsync(url))
            {
                productList = await response.Content.ReadFromJsonAsync<List<ProductListDTO>>() ?? new();
            }

            if (!string.IsNullOrWhiteSpace(q))
            {
                TempData["search"] = q;

                productList = productList.Where(s => s.Name!.ToLower().Contains(q.ToLower()))
                                                            .ToList();
            }
            else
            {
                TempData["search"] = "";
            }

            var categoriesList = new List<CategoryListDTO>();
            using (var response = await _httpClient.GetAsync("Categories"))
            {
                categoriesList = await response.Content.ReadFromJsonAsync<List<CategoryListDTO>>() ?? new();
            }

            ProductListViewModel productAndSearch = new();
            productAndSearch.ProductList = productList;
            productAndSearch.Categories = categoriesList;

            return View(productAndSearch);
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            using (var response = await _httpClient.GetAsync($"Product/{id}"))
            {
                var product = await response.Content.ReadFromJsonAsync<ProductDetailDTO>() ?? new ProductDetailDTO();
                return View(product);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

