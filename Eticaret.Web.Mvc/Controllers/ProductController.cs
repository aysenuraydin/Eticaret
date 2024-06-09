using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Eticaret.File.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize(Roles = "seller")]
    public class ProductController : Controller
    {
        private HttpClient _httpClient;
        private HttpClient _httpClientFile;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");

            _httpClientFile = httpClientFactory.CreateClient();
            _httpClientFile.BaseAddress = new Uri("http://localhost:5112/api/");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync($"SellerProduct");

                if (response.IsSuccessStatusCode)
                {
                    var products = await response.Content.ReadFromJsonAsync<List<AdminProductListDTO>>() ?? new List<AdminProductListDTO>();
                    return View(products);
                }
                else
                {
                    return View(new List<AdminProductListDTO>());
                }


            }
            catch (Exception)
            {
                return View("Error");
            }
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
                    var prd = await CreateImage(product, ImageList);
                    var json = JsonSerializer.Serialize(prd);

                    var response = await _httpClient.PostAsync("SellerProduct", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
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

        public async Task<SellerProductCreateDTO> CreateImage(SellerProductCreateDTO product, List<IFormFile> imageList)
        {
            if (imageList.Count > 0)
            {
                product.ImageList.Clear();
                for (int i = 0; i < imageList.Count; i++)
                {
                    var Url = await AddImg(imageList[i]);
                    var x = new UpdateImage()
                    {
                        Url = Url,
                        ProductId = product.Id,
                        SellerId = product.SellerId
                    };
                    product.ImageList.Add(x);
                }
            }
            return product;
        }

        public async Task<string> AddImg(IFormFile ImageList)
        {
            try
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StreamContent(ImageList.OpenReadStream()), "file", ImageList.FileName);

                var response = await _httpClientFile.PostAsync("File", formData);
                if (response.IsSuccessStatusCode)
                {
                    var imgUrl = await response.Content.ReadFromJsonAsync<FileEntity>();

                    if (imgUrl != null) return imgUrl.LocalName!;
                    return "";
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();

                    ViewBag.Error = error;
                    return "";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return ex.Message;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            using (var response = await _httpClient.GetAsync($"SellerProduct/{id}"))
            {
                SellerProductUpdateDTO product = await response.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();

                // int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int seller);
                // product.SellerId = seller;

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
                    var resp = await _httpClient.GetAsync($"SellerProduct/{product.Id}");

                    if (resp.IsSuccessStatusCode)
                    {
                        SellerProductUpdateDTO p = await resp.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();
                        var images = p.ImageList;
                        foreach (var item in images)
                        {
                            await RemoveImg(item);
                        }
                        var prd = await CreateImage(TransformProduct(product), ImageList);
                        var json = JsonSerializer.Serialize(prd);

                        var response = await _httpClient.PutAsync($"SellerProduct/{product.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(Index), "Product");
                        }
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.GetAsync($"SellerProduct/{id}"))
            {
                var product = await response.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();

                if (response.IsSuccessStatusCode)
                {
                    return View(product);
                }
                return RedirectToAction(nameof(Index), "Product");

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SellerProductUpdateDTO? p)
        {
            try
            {
                var resp = await _httpClient.GetAsync($"SellerProduct/{id}");
                if (resp.IsSuccessStatusCode)
                {
                    SellerProductUpdateDTO product = await resp.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();

                    var response = await _httpClient.DeleteAsync($"SellerProduct/{id}");

                    foreach (var item in product.ImageList)
                    {
                        await RemoveImg(item);
                    }
                    return RedirectToAction(nameof(Index), "Product");
                }
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
        public async Task<IActionResult> Comment(int ProductId, byte StarCount, string Text)
        {
            if (StarCount != 0 && Text != null && ProductId != 0)
            {
                try
                {
                    var comment = new ProductCommentCreateDTO()
                    {
                        Text = Text,
                        StarCount = StarCount,
                        ProductId = ProductId
                    };
                    var json = JsonSerializer.Serialize(comment);

                    var response = await _httpClient.PostAsync("ProductComment", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToRoute(new
                        {
                            //controller = nameof(HomeController).Replace("Controller", string.Empty),
                            controller = "Home",
                            action = nameof(HomeController.ProductDetail),
                            id = ProductId
                        });
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return RedirectToRoute(new
            {
                //controller = nameof(HomeController).Replace("Controller", string.Empty),
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

        public async Task RemoveImg(string url)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"File/{url}");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
        }
        public SellerProductCreateDTO TransformProduct(SellerProductUpdateDTO product)
        {
            var p = new SellerProductCreateDTO();


            p.Id = product.Id;
            p.Name = product.Name;
            p.Price = product.Price;
            p.Details = product.Details;
            foreach (var item in product.ImageList)
            {
                UpdateImage img = new()
                {
                    Url = item,
                    ProductId = product.Id,
                    SellerId = product.SellerId
                };
                p.ImageList.Add(img);
            }
            p.StockAmount = product.StockAmount;
            p.CategoryId = product.CategoryId;
            p.SellerId = product.SellerId;
            p.Enabled = product.Enabled;

            return p;
        }


    }
}