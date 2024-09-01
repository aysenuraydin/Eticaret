using Eticaret.Domain.Constants;
using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize(Roles = Roles.Seller)]
    public class ProductController : AppController
    {
        private HttpClient _httpClient;
        private HttpClient _httpClientFile;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
            _httpClientFile = httpClientFactory.CreateClient(ApplicationSettings.FILE_API_CLIENT);
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"SellerProduct");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<List<AdminProductListDTO>>() ?? new();

                return View(products);
            }

            ViewBagMessage(response.ReasonPhrase);

            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SellerProductCreateOrUpdateDTO product, List<IFormFile> ImageList)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Eksik veri girdiniz!");
                ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");

                return View(product);
            }

            for (int i = 0; i < ImageList.Count; i++)
            {
                var Url = await AddImg(ImageList[i]);
                product.ImageList.Add(Url);
            }

            var response = await _httpClient.PostAsJsonAsync("SellerProduct", product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBagMessage(response.ReasonPhrase);
            ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");

            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");

            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Category = new SelectList(await GetCategories(), "Id", "Name");

            using (var response = await _httpClient.GetAsync($"SellerProduct/{id}"))
            {
                SellerProductCreateOrUpdateDTO product = await response.Content.ReadFromJsonAsync<SellerProductCreateOrUpdateDTO>() ?? new();

                if (response.IsSuccessStatusCode) return View(product);

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SellerProductCreateOrUpdateDTO product, List<IFormFile> ImgList)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
                return View(product);
            }

            var resp = await _httpClient.GetAsync($"SellerProduct/{product.Id}");

            if (!resp.IsSuccessStatusCode) return View(product);

            SellerProductCreateOrUpdateDTO prd = await resp.Content.ReadFromJsonAsync<SellerProductCreateOrUpdateDTO>() ?? new();

            foreach (var item in prd.ImageList)
            {
                await _httpClientFile.DeleteAsync($"File/{item}");
            }

            product.ImageList.Clear();

            for (int i = 0; i < ImgList.Count; i++)
            {
                product.ImageList.Add(await AddImg(ImgList[i]));
            }

            var response = await _httpClient.PutAsJsonAsync($"SellerProduct/{product.Id}", product);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.GetAsync($"SellerProduct/{id}"))
            {
                var product = await response.Content.ReadFromJsonAsync<SellerProductCreateOrUpdateDTO>() ?? new();

                if (response.IsSuccessStatusCode) return View(product);

                ViewBagMessage(response.ReasonPhrase);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SellerProductCreateOrUpdateDTO? p)
        {
            var resp = await _httpClient.GetAsync($"SellerProduct/{id}");

            if (!resp.IsSuccessStatusCode)
            {
                ViewBagMessage(resp.ReasonPhrase);
                return RedirectToAction(nameof(Delete), new { id = id });
            }
            SellerProductCreateOrUpdateDTO product = await resp.Content.ReadFromJsonAsync<SellerProductCreateOrUpdateDTO>() ?? new();

            var response = await _httpClient.DeleteAsync($"SellerProduct/{id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBagMessage(response.ReasonPhrase);
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            foreach (var item in product.ImageList)
            {
                await _httpClientFile.DeleteAsync($"File/{item}");
            }

            return RedirectToAction(nameof(Index));
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
                    ViewBagMessage(response.ReasonPhrase);
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

        public async Task<List<CategoryListDTO>> GetCategories()
        {
            using (var response = await _httpClient.GetAsync("Categories"))
            {
                List<CategoryListDTO> products = await response.Content.ReadFromJsonAsync<List<CategoryListDTO>>() ?? new();

                return products;
            }
        }
        public async Task<string> AddImg(IFormFile ImageList)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(ImageList.OpenReadStream()), "file", ImageList.FileName);

            var response = await _httpClientFile.PostAsync("File", formData);

            if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();

            throw new Exception("File not upload");
        }
        //  public async Task<string> AddImg(IFormFile image) => await fileService.UploadFileAsync(image) ?? string.Empty;
    }
}
//!!! listeleri foreach sız aktarma  addrange;?


