using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CSSimApp.BLL.Dtos;
using CSSimApp.BLL.Services;

namespace CSSimApp.UI.Controllers.Api
{
    public class BouquetMaterialsController : ApiController
    {
        private BouquetMaterialManager _bmm;

        public BouquetMaterialsController()
        {
            _bmm = new BouquetMaterialManager();
        }
        // GET /api/BouquetMaterials
        public IHttpActionResult GetBouquetMaterials()
        {
            var bouquetMaterialDtos = _bmm.GetAll();

            return Ok(bouquetMaterialDtos);
        }

        // GET /api/BouquetMaterials/1

        public IHttpActionResult GetBouquetMaterial(int id)
        {
            var bouquetMaterialDto = _bmm.Get(id);
            if (bouquetMaterialDto == null)
                return NotFound();
            return Ok(bouquetMaterialDto);
        }

        // POST /api/BouquetMaterials
        [HttpPost]
        public IHttpActionResult CreateBouquetMaterial(BouquetMaterialDto bouquetMaterialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_bmm.Add(bouquetMaterialDto))
            {
                bouquetMaterialDto.Id = bouquetMaterialDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + bouquetMaterialDto.Id), bouquetMaterialDto);
            }
            return BadRequest();

        }


        // PUT /api/BouquetMaterials/1
        [HttpPut]
        public IHttpActionResult UpdateBouquetMaterial(int id, BouquetMaterialDto bouquetMaterialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bouquetMaterialInDb = _bmm.Get(id);

            if (bouquetMaterialInDb == null)
                return NotFound();


            var updatedBouquetMaterialDto = Mapper.Map(bouquetMaterialDto, bouquetMaterialInDb);

            if (_bmm.Update(id, updatedBouquetMaterialDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/BouquetMaterials/1
        [HttpDelete]
        public IHttpActionResult DeleteBouquetMaterial(int id)
        {
            var bouquetMaterialInDb = _bmm.Get(id);

            if (bouquetMaterialInDb == null)
                return NotFound();

            if (_bmm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
