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
    public class MaterialsController : Controller
    {
        private MaterialManager _mm;

        public MaterialsController()
        {
            _mm=new MaterialManager();
        }
        // GET: Materials
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var material = _mm.Get(id);
            if (material == null)
                return HttpNotFound();
            return View(material);
        }

        public ActionResult New()
        {
            var viewModel = new MaterialFormViewModel
            {
                Material = new MaterialDto()
            };

            return View("MaterialForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MaterialDto material)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MaterialFormViewModel
                {
                    Material = material
                };
                return View("MaterialForm", viewModel);
            }

            if (material.Id == 0)
            {
                _mm.Add(material);
            }
            else
            {
                _mm.Update(material.Id,material);
            }
            return RedirectToAction("Index","Materials");
        }

        public ActionResult Edit(int id)
        {
            var materialInDb = _mm.Get(id);
            if (materialInDb == null)
                return HttpNotFound();

            var viewModel = new MaterialFormViewModel
            {
                Material = materialInDb
            };

            return View("MaterialForm",viewModel);
        }
    }
}