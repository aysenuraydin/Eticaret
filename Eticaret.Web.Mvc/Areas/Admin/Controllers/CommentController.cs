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
    public class CommentController : Controller
    {
        private readonly IProductCommentRepository _commentService;

        public CommentController(IProductCommentRepository commentService)
        {
            _commentService = commentService;
        }

        public IActionResult List()
        {
            var comments = _commentService.GetDb()
                                .Include(c => c.UserFk)
                                .Include(c => c.ProductFk)
                                .OrderByDescending(p => !p.IsConfirmed)
                                .ToList();

            return View(comments);
        }
        public IActionResult Approve(int id)
        {
            var comment = _commentService.GetDb()
                                .Include(c => c.UserFk)
                                .Include(c => c.ProductFk)
                                .FirstOrDefault(p => p.Id == id);

            return View(comment);
        }
        [HttpPost]
        public IActionResult Approve(ProductComment comment)
        {
            try
            {
                _commentService.Update(comment);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View(comment);
            }
        }
        public IActionResult Delete(int id)
        {
            var comment = _commentService.GetDb()
                                .Include(c => c.UserFk)
                                .Include(c => c.ProductFk)
                                .FirstOrDefault(p => p.Id == id);

            return View(comment);
        }
        [HttpPost]
        public IActionResult Delete(int id, ProductComment comment)
        {
            try
            {
                _commentService.Delete(comment);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View(id);
            }
        }
    }
}