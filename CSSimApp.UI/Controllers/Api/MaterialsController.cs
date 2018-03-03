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
    public class MaterialsController : ApiController
    {
        private MaterialManager _mm;

        public MaterialsController()
        {
            _mm = new MaterialManager();
        }
        // GET /api/Materials
        public IHttpActionResult GetMaterials()
        {
            var materialDtos = _mm.GetAll();

            return Ok(materialDtos);
        }

        // GET /api/Materials/1

        public IHttpActionResult GetMaterial(int id)
        {
            var materialDto = _mm.Get(id);
            if (materialDto == null)
                return NotFound();
            return Ok(materialDto);
        }

        // POST /api/Materials
        [HttpPost]
        public IHttpActionResult CreateMaterial(MaterialDto materialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_mm.Add(materialDto))
            {
                materialDto.Id = materialDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + materialDto.Id), materialDto);
            }
            return BadRequest();

        }


        // PUT /api/Materials/1
        [HttpPut]
        public IHttpActionResult UpdateMaterial(int id, MaterialDto materialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var materialInDb = _mm.Get(id);

            if (materialInDb == null)
                return NotFound();


            var updatedMaterialDto = Mapper.Map(materialDto, materialInDb);

            if (_mm.Update(id, updatedMaterialDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Materials/1
        [HttpDelete]
        public IHttpActionResult DeleteMaterial(int id)
        {
            var materialInDb = _mm.Get(id);

            if (materialInDb == null)
                return NotFound();

            if (_mm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
