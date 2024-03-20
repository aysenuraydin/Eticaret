using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Web.Mvc.Models;
using Eticaret.Web.Mvc.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize(Roles = "seller")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productService;
        private readonly IProductCommentRepository _productCommentService;
        private readonly ICategoryRepository _categoryService;
        private readonly IProductImageRepository _productImageService;

        public ProductController(IProductRepository productService,
        IProductCommentRepository productCommentService,
        IProductImageRepository productImageService,
        ICategoryRepository categoryService)
        {
            _productService = productService;
            _productCommentService = productCommentService;
            _productImageService = productImageService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null && int.TryParse(userId, out int Id))
            {
                var product = _productService.GetDb()
                               .Include(i => i.CategoryFk)
                               .Include(i => i.SellerFk)
                               .Include(i => i.CartItems)
                               .Include(i => i.ProductComments)
                               .Include(i => i.ProductImages)
                               .Include(i => i.OrderItems)
                               .Where(u => u.SellerId == Id)
                               .OrderBy(p => p.IsConfirmed)
                               .ToList();
                return View(product);
            }
            else return BadRequest();
        }
        public async Task<IActionResult> Create()
        {
            bool Id = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int sellerId);
            var product = new Product() { SellerId = sellerId };


            ViewBag.Category = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, List<IFormFile> ProductImages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ProductImages != null && ProductImages.Any())
                    {
                        _productService.Add(product);

                        List<ProductImage> img = new List<ProductImage>();
                        foreach (var item in ProductImages)
                        {
                            img.Add(new()
                            {
                                Url = await FileHelper.FileLoaderAsync(item),
                                ProductId = product.Id,
                                SellerId = product.SellerId
                            });
                        }
                        img.ForEach(item => _productImageService.Add(item));
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.Category = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View(product);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = _productService.GetDb()
                                .Include(i => i.CategoryFk)
                                .Include(i => i.SellerFk)
                                .Include(i => i.CartItems)
                                .Include(i => i.ProductComments)
                                .Include(i => i.ProductImages)
                                .Include(i => i.OrderItems)
                                .FirstOrDefault(p => p.Id == id);

            ViewBag.Category = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product, List<IFormFile> ProductImages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(product);
                    if (ProductImages != null && ProductImages.Any())
                    {
                        List<ProductImage> img = new List<ProductImage>();
                        foreach (var item in ProductImages)
                        {
                            img.Add(new()
                            {
                                Url = await FileHelper.FileLoaderAsync(item),
                                ProductId = product.Id,
                                SellerId = product.SellerId
                            });
                        }
                        _productImageService.GetAll()
                                    .Where(i => i.ProductId == product.Id).ToList()
                                    .ForEach(item => _productImageService.Delete(item));

                        img.ForEach(item => _productImageService.Add(item));
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            ViewBag.Category = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            var product = _productService.GetDb()
                               .Include(i => i.CategoryFk)
                               .Include(i => i.SellerFk)
                               .Include(i => i.CartItems)
                               .Include(i => i.ProductImages)
                               .Include(i => i.ProductComments)
                               .Include(i => i.OrderItems)
                               .FirstOrDefault(p => p.Id == id);

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            try
            {
                //wroot içinden de  silmmeiz lazım .Net Core delete image araştır =>
                _productService.Delete(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
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
    }
}