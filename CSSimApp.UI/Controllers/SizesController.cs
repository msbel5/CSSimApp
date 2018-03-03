using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSSimApp.BLL.Dtos;
using CSSimApp.BLL.Services;
using CSSimApp.UI.ViewModels;

namespace CSSimApp.UI.Controllers
{
    [Authorize]
    public class SizesController : Controller
    {
        private SizeManager _sm;

        public SizesController()
        {
            _sm = new SizeManager();
        }
        // GET: Sizes
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var size = _sm.Get(id);
            if (size == null)
                return HttpNotFound();
            return View(size);
        }

        public ActionResult New()
        {
            var viewModel = new SizeFormViewModel
            {
                Size = new SizeDto()
            };

            return View("SizeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SizeDto size)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SizeFormViewModel
                {
                    Size = size
                };
                return View("SizeForm", viewModel);
            }

            if (size.Id == 0)
            {
                _sm.Add(size);
            }
            else
            {
                _sm.Update(size.Id, size);
            }
            return RedirectToAction("Index", "Sizes");
        }

        public ActionResult Edit(int id)
        {
            var sizeInDb = _sm.Get(id);
            if (sizeInDb == null)
                return HttpNotFound();

            var viewModel = new SizeFormViewModel
            {
                Size = sizeInDb
            };

            return View("SizeForm", viewModel);
        }
    }
}