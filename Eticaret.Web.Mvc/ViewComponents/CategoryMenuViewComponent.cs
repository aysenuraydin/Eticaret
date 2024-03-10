using Eticaret.Application.Abstract;
using Eticaret.Persistence.Ef;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private ICategoryRepository _repository;//şimdilik bu şekilde

        public CategoryMenuViewComponent(ICategoryRepository repo)
        {
            _repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            var action = RouteData.Values["action"];
            if (action != null && action.ToString() == "Index")
                ViewBag.SelectedCategory = RouteData?.Values["id"];
            return View(_repository.GetAll());
        }
    }

}
