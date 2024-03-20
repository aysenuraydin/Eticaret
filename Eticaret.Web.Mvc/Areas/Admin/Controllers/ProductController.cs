using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productService;

        public ProductController(IProductRepository productService)
        {
            _productService = productService;
        }

        public IActionResult List()
        {
            var product = _productService.GetDb()
                            .Include(i => i.CategoryFk)
                            .Include(i => i.SellerFk)
                            .Include(i => i.CartItems)
                            .Include(i => i.ProductComments)
                            .Include(i => i.ProductImages)
                            .Include(i => i.OrderItems)
                            .OrderBy(p => p.IsConfirmed)
                            .ToList();

            return View(product);
        }
        public IActionResult Approve(int id)
        {
            var product = _productService.GetDb()
                                .Include(i => i.CategoryFk)
                                .Include(i => i.SellerFk)
                                .Include(i => i.CartItems)
                                .Include(i => i.ProductComments)
                                .Include(i => i.ProductImages)
                                .Include(i => i.OrderItems)
                                .FirstOrDefault(p => p.Id == id);

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Approve(Product product)
        {
            try
            {
                _productService.Update(product);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View(product);
            }
        }
        public IActionResult Delete(int id)
        {
            var product = _productService.GetDb()
                                .Include(i => i.CategoryFk)
                                .Include(i => i.SellerFk)
                                .Include(i => i.CartItems)
                                .Include(i => i.ProductComments)
                                .Include(i => i.ProductImages)
                                .Include(i => i.OrderItems)
                                .FirstOrDefault(p => p.Id == id);

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product product)
        {
            try
            {
                _productService.Delete(product);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View(id);
            }

        }
    }
}
