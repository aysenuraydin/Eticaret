using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Eticaret.Web.Mvc.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize(Roles = "seller")]
    public class ProductController : Controller
    {
        private readonly IProductCommentRepository _productCommentService;
        private HttpClient _httpClient;

        public ProductController(
        IProductCommentRepository productCommentService,
        IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");

            _productCommentService = productCommentService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null && int.TryParse(userId, out int Id))
            {
                using (var response = await _httpClient.GetAsync($"SellerProduct/All/{userId}"))
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
            else return BadRequest();
        }

        public async Task<IActionResult> Create()
        {
            bool Id = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int sellerId);
            var product = new SellerProductCreateDTO() { SellerId = sellerId };


            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SellerProductCreateDTO product, List<IFormFile> ImageList)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonSerializer.Serialize(product);

                    var response = await _httpClient.PostAsync("SellerProduct", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var newProduct = await response.Content.ReadFromJsonAsync<SellerProductCreateDTO>();

                        CreateImage(newProduct!, ImageList);
                        return RedirectToAction(nameof(Index), "Product");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");
            return View(product);

        }

        public async void CreateImage(SellerProductCreateDTO product, List<IFormFile> ImageList)
        {
            if (ImageList != null && ImageList.Any())
            {
                foreach (var item in ImageList)
                {
                    try
                    {
                        var json = JsonSerializer.Serialize(
                             new ProductImageCreateDTO()
                             {
                                 Url = await FileHelper.FileLoaderAsync(item),
                                 ProductId = product.Id,
                                 SellerId = product.SellerId
                             }
                        );

                        var response = await _httpClient.PostAsync("ProductImage", new StringContent(json, Encoding.UTF8, "application/json"));

                        if (response.IsSuccessStatusCode)
                        {
                            var newCategory = await response.Content.ReadFromJsonAsync<ProductImage>();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = ex.Message;
                    }
                }
            }
        }
        public async void DeleteImage(SellerProductCreateDTO product)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"ProductImage/{product.Id}");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            using (var response = await _httpClient.GetAsync($"SellerProduct/{id}"))
            {
                SellerProductUpdateDTO product = await response.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();
                ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");
                return View(product);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SellerProductUpdateDTO product, List<IFormFile> ImageList)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonSerializer.Serialize(product);

                    var response = await _httpClient.PutAsync($"SellerProduct/{product.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var newProduct = await response.Content.ReadFromJsonAsync<SellerProductCreateDTO>();

                        DeleteImage(newProduct!);
                        CreateImage(newProduct!, ImageList);

                        return RedirectToAction(nameof(Index), "Product");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");
            return View(product);
        }



        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.GetAsync($"SellerProduct/{id}"))
            {
                var product = await response.Content.ReadFromJsonAsync<SellerProductListDTO>() ?? new();
                return View(product);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SellerProductListDTO category)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"SellerProduct/{id}");

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index), "Product");
                else
                    return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Comment(int ProductId, byte StarCount, string Text)
        {
            if (StarCount != 0 && Text != null && ProductId != 0)
            {
                try
                {
                    var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (userIdClaim != null && int.TryParse(userIdClaim, out int userId))
                    {
                        var comment = new ProductComment() { Text = Text, StarCount = StarCount, UserId = userId, ProductId = ProductId };
                        _productCommentService.Add(comment!);
                    }
                    return RedirectToRoute(new
                    {
                        //controller = nameof(HomeController).Replace("Controller", string.Empty),
                        controller = "Home",
                        action = nameof(HomeController.ProductDetail),
                        id = ProductId
                    });
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return RedirectToRoute(new
            {
                controller = "Home",
                action = nameof(HomeController.ProductDetail),
                id = ProductId
            });
        }

        public async Task<List<CategoryListDTO>> GetCategories()
        {
            using (var response = await _httpClient.GetAsync("Categories"))
            {
                List<CategoryListDTO> products = await response.Content.ReadFromJsonAsync<List<CategoryListDTO>>() ?? new();

                return products;
            }
        }
    }
}