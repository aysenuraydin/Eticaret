using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize(Roles = "seller")]
    public class ProductController(IHttpClientFactory httpClientFactory, IFileService fileService) : Controller
    {
        private HttpClient _httpClient = httpClientFactory.CreateClient("api");

        public async Task<IActionResult> Index()
        {
            if (TempData["ErrorMessage"] != null) ViewBag.ErrorMessage = TempData["ErrorMessage"];

            var response = await _httpClient.GetAsync($"SellerProduct");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<List<AdminProductListDTO>>() ?? new();

                return View(products);
            }

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";

            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SellerProductCreateDTO product, List<IFormFile> ImageList)
        {
            if (ModelState.IsValid)
            {
                var prd = await CreateImage(product, ImageList);

                var response = await _httpClient.PostAsJsonAsync("SellerProduct", prd);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");
            }

            ModelState.AddModelError("", "Eksik veri girdiniz!");
            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");

            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");

            using (var response = await _httpClient.GetAsync($"SellerProduct/{id}"))
            {
                SellerProductUpdateDTO product = await response.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();

                if (response.IsSuccessStatusCode) return View(product);

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SellerProductUpdateDTO product, List<IFormFile> ImgList)
        {
            if (ModelState.IsValid)
            {
                var resp = await _httpClient.GetAsync($"SellerProduct/{product.Id}");

                if (resp.IsSuccessStatusCode)
                {
                    SellerProductUpdateDTO p = await resp.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();

                    if (ImgList.Count > 0)
                    {
                        var images = p.ImageList;

                        foreach (var item in images)
                        {
                            await RemoveImg(item);
                        }
                    }

                    var transformProduct = TransformProduct(product);
                    var prd = await CreateImage(transformProduct, ImgList);

                    var response = await _httpClient.PutAsJsonAsync($"SellerProduct/{product.Id}", prd);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                }

                ViewBag.ErrorMessage = $"Error: {resp.ReasonPhrase}";
            }

            ModelState.AddModelError("", "Hata Oluştu!");
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (TempData["ErrorMessage"] != null) ViewBag.ErrorMessage = TempData["ErrorMessage"];

            using (var response = await _httpClient.GetAsync($"SellerProduct/{id}"))
            {
                var product = await response.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();

                if (response.IsSuccessStatusCode) return View(product);

                TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SellerProductUpdateDTO? p)
        {
            var resp = await _httpClient.GetAsync($"SellerProduct/{id}");

            if (resp.IsSuccessStatusCode)
            {
                SellerProductUpdateDTO product = await resp.Content.ReadFromJsonAsync<SellerProductUpdateDTO>() ?? new();

                var response = await _httpClient.DeleteAsync($"SellerProduct/{id}");

                if (response.IsSuccessStatusCode)
                {
                    foreach (var item in product.ImageList)
                    {
                        await RemoveImg(item);
                    }

                    return RedirectToAction(nameof(Index));
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }

            TempData["ErrorMessage"] = $"Error: {resp.ReasonPhrase}";

            return RedirectToAction(nameof(Delete), new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Comment(int ProductId, byte StarCount, string Text)
        {
            TempData["Message"] = null;

            if (StarCount != 0 && Text != null && ProductId != 0)
            {
                ProductCommentCreateDTO cmnt = new()
                {
                    Text = Text,
                    StarCount = StarCount,
                    ProductId = ProductId
                };

                var response = await _httpClient.PostAsJsonAsync("ProductComment", cmnt);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["Message"] = $"Error: {response.ReasonPhrase}";
                }
            }
            else TempData["Message"] = $"Error: Hata oluştu! Eksik bilgi girdiniz.";

            return RedirectToRoute(new
            {
                action = "ProductDetail",
                controller = "Home",
                id = ProductId
            });
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

        public async Task<List<CategoryListDTO>> GetCategories()
        {
            using (var response = await _httpClient.GetAsync("Categories"))
            {
                List<CategoryListDTO> products = await response.Content.ReadFromJsonAsync<List<CategoryListDTO>>() ?? new();

                return products;
            }
        }

        public async Task<string> AddImg(IFormFile image) => await fileService.UploadFileAsync(image) ?? string.Empty;

        public async Task<bool> RemoveImg(string url)
        {
            var response = await _httpClientFile.DeleteAsync($"File/{url}");

            if (response.IsSuccessStatusCode) return true;

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";

            return false;
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
    }
}
