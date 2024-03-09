using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productService;

        public ProductController(IProductRepository productService)
        {
            _productService = productService;
            //_catagorService = catagorService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();

            return View(products);
        }
        public IActionResult Create()
        {
            // ViewBag.BrandId = new SelectList(await _databaseContext.Brands.ToListAsync(), "Id", "Name");
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(p);
                return RedirectToAction(nameof(Index));
                /*
                 try
                 {
                     product.Image = await FileHelper.FileLoaderAsync(Image);
                     await _databaseContext.Products.AddAsync(product);//bu yöntemi kullandık
                     await _databaseContext.SaveChangesAsync();
                     return RedirectToAction(nameof(Index));
                 }
                 catch
                 {
                     ModelState.AddModelError("", "Hata Oluştu!");
                 }
                 */
            }
            // ViewBag.BrandId = new SelectList(await _databaseContext.Brands.ToListAsync(), "Id", "Name");
            return View(p);
        }
        public IActionResult Edit(int id)
        {
            return View(_productService.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            try
            {
                _productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }
        public IActionResult Delete(int id)
        {
            return View(_productService.Find(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            try
            {
                _productService.Delete(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Comment()
        {
            return View();
        }

    }
}