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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryService;

        public CategoryController(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Add(category);
                    return RedirectToAction(nameof(Index), "Home");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(category);
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetDb().
                                Include(c => c.Products)
                               .FirstOrDefault(p => p.Id == id);


            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Update(category);
                    return RedirectToAction(nameof(Index), "Home");
                    //return RedirectToAction(nameof(Index), nameof(HomeController).Replace("Controller", string.Empty));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(category);
        }
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetDb().
                                Include(c => c.Products)
                               .FirstOrDefault(p => p.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(int id, Category category)
        {
            try
            {
                _categoryService.Delete(category);
                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return View();
            }

        }
    }
}



