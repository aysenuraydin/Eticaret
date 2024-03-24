using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryService;
        private readonly IProductRepository _productService;
        private readonly IProductCommentRepository _productCommentService;

        public HomeController(ICategoryRepository categoryService, IProductRepository productService, IProductCommentRepository productCommentService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _productCommentService = productCommentService;
        }

        public IActionResult Index()
        {
            var produsts = _productService.GetDb()
                                            .Where(p => p.IsConfirmed && p.Enabled)
                                            .Include(p => p.ProductImages)
                                            .Where(p => p.StockAmount > 0)
                                            .OrderByDescending(p => p.CreatedAt)
                                            .ToList();
            return View(produsts);
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
            var productList = await _productService.GetIdAllIncludeFilterAsync(
                                        p => p.IsConfirmed && p.Enabled && p.StockAmount > 0,
                                        p => p.ProductImages
                                       );



            if (id != null) productList = productList.Where(c => c.CategoryId == id)
                                                        .ToList();

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
            ProductListViewModel productAndSearch = new();
            productAndSearch.ProductList = productList.OrderByDescending(p => p.CreatedAt).ToList();
            productAndSearch.Categories = _categoryService.GetAll();

            return View(productAndSearch);
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _productService.GetDb()
                                .Include(i => i.ProductComments)
                                .ThenInclude(i => i.UserFk)
                                .Include(p => p.ProductImages)
                                .Include(p => p.CategoryFk)
                                .FirstOrDefault(p => p.Id == id);
            return View(product);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

