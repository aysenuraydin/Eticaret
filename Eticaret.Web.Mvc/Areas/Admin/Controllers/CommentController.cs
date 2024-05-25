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
    public class CommentController : Controller
    {
        private readonly HttpClient _httpClient;
        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }

        public async Task<IActionResult> List()
        {
            using (var response = await _httpClient.GetAsync("AdminProductComment"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var comments = await response.Content.ReadFromJsonAsync<List<AdminProductCommentListDTO>>() ?? new List<AdminProductCommentListDTO>();
                    return View(comments);
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
            using (var response = await _httpClient.GetAsync($"AdminProductComment/{id}"))
            {
                AdminProductCommentListDTO comment = await response.Content.ReadFromJsonAsync<AdminProductCommentListDTO>() ?? new();
                return View(comment);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(ProductComment comment)
        {
            try
            {
                var json = JsonSerializer.Serialize(comment);

                var response = await _httpClient.PutAsync($"AdminProductComment/{comment.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var updateBook = await response.Content.ReadFromJsonAsync<AdminProductCommentListDTO>();
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
            using (var response = await _httpClient.GetAsync($"AdminProductComment/{id}"))
            {
                AdminProductCommentListDTO product = await response.Content.ReadFromJsonAsync<AdminProductCommentListDTO>() ?? new();
                return View(product);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ProductComment? comment)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"AdminProductComment/{id}");

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