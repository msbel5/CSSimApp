using System;
using System.Collections;
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
    public class HomeController : Controller
    {
        private BouquetManager _bm;
        private BouquetMaterialManager _bmm;
        private SizeManager _sm;
        private MaterialManager _mm;

        public HomeController()
        {
            _bm = new BouquetManager();
            _bmm = new BouquetMaterialManager();
            _sm = new SizeManager();
            _mm = new MaterialManager();
        }
        // GET: Bouquets
        [AllowAnonymous]
        public ActionResult Index()
        {
            var viewModel = _bm.EagerGetAll();
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var Bouquet = _bm.Get(id);
            if (Bouquet == null)
                return HttpNotFound();
            return View(Bouquet);
        }

        public ActionResult New()
        {
            IEnumerable<SizeDto> sizeDtos = _sm.GetAll();
            var sizeDtoList = sizeDtos as SizeDto[] ?? sizeDtos.ToArray();
            SelectList sizeDtoSelectList = new SelectList(sizeDtoList,"Id","Name");

            var materials = _mm.GetAll();

            List<BouquetMaterialDto> bouquetMaterialDtos = new List<BouquetMaterialDto>();
            foreach (MaterialDto material in materials)
            {
                BouquetMaterialDto bmDto = new BouquetMaterialDto
                {
                    MaterialId = material.Id,
                    Material = material,
                    Quantity = 0
                };
                bouquetMaterialDtos.Add(bmDto);
            }

            var viewModel = new BouquetFormViewModel
            {
                Bouquet = new BouquetDto(),
                SizeList = sizeDtoSelectList,
                BouquetMaterials = bouquetMaterialDtos
            };

            return View("BouquetForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BouquetFormViewModel bouquetFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("New","Home");
            }

            if (bouquetFormViewModel.Bouquet.Id == 0)
            {
                var bouquet = new BouquetDto();

                bouquet.SizeId = _sm.Get(bouquetFormViewModel.Bouquet.SizeId).Id;
                //bouquet.Size = _sm.Get(bouquetFormViewModel.Bouquet.SizeId);

                IList<BouquetMaterialDto> bouquetMaterialDtos = new List<BouquetMaterialDto>();
                foreach (BouquetMaterialDto bouquetMaterial in bouquetFormViewModel.BouquetMaterials)
                {
                    if (bouquetMaterial.Quantity > 0)
                    {
                        var bMaterial = new BouquetMaterialDto();
                        bMaterial.Quantity = bouquetMaterial.Quantity;
                        var material = _mm.Get(bouquetMaterial.Material.Id);
                        bMaterial.Material = material;
                        bMaterial.MaterialId = material.Id;
                        bMaterial.Bouquet = bouquet;
                        bouquetMaterialDtos.Add(bMaterial);
                    }
                        
                }
                
                bouquet.Materials = bouquetMaterialDtos;

                bouquet.Name = bouquetFormViewModel.Bouquet.Name;
                bouquet.Price = bouquetFormViewModel.Bouquet.Price;
                
                _bm.Add(bouquet);
            }
            else
            {
                IList<BouquetMaterialDto> bouquetMaterialDtos = new List<BouquetMaterialDto>();
                foreach (BouquetMaterialDto bouquetMaterial in bouquetFormViewModel.BouquetMaterials)
                {
                    if (bouquetMaterial.Quantity > 0)
                        bouquetMaterialDtos.Add(bouquetMaterial);
                }
                bouquetFormViewModel.Bouquet.Materials = bouquetMaterialDtos;

                _bm.Update(bouquetFormViewModel.Bouquet.Id, bouquetFormViewModel.Bouquet);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var bouquetInDb = _bm.Get(id);
            if (bouquetInDb == null)
                return HttpNotFound();

            IEnumerable<SizeDto> sizeDtos = _sm.GetAll();
            var sizeDtoList = sizeDtos as SizeDto[] ?? sizeDtos.ToArray();
            SelectList sizeDtoSelectList = new SelectList(sizeDtoList, "Id", "Name");

            var materials = _mm.GetAll();

            List<BouquetMaterialDto> bouquetMaterialDtos = new List<BouquetMaterialDto>();
            foreach (MaterialDto material in materials)
            {
                BouquetMaterialDto bmDto = new BouquetMaterialDto
                {
                    MaterialId = material.Id,
                    Material = material,
                    Quantity = 0
                };
                bouquetMaterialDtos.Add(bmDto);
            }

            var viewModel = new BouquetFormViewModel
            {
                Bouquet = bouquetInDb,
                SizeList = sizeDtoSelectList,
                BouquetMaterials = bouquetMaterialDtos
            };


            return View("BouquetForm", viewModel);
        }
    }
}