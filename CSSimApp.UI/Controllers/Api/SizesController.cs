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
    public class SizesController : ApiController
    {
        private SizeManager _sm;

        public SizesController()
        {
            _sm = new SizeManager();
        }
        // GET /api/Sizes
        public IHttpActionResult GetSizes()
        {
            var sizeDtos = _sm.GetAll();

            return Ok(sizeDtos);
        }

        // GET /api/Sizes/1

        public IHttpActionResult GetSize(int id)
        {
            var sizeDto = _sm.Get(id);
            if (sizeDto == null)
                return NotFound();
            return Ok(sizeDto);
        }

        // POST /api/Sizes
        [HttpPost]
        public IHttpActionResult CreateSize(SizeDto sizeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_sm.Add(sizeDto))
            {
                sizeDto.Id = sizeDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + sizeDto.Id), sizeDto);
            }
            return BadRequest();

        }


        // PUT /api/Sizes/1
        [HttpPut]
        public IHttpActionResult UpdateSize(int id, SizeDto sizeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sizeInDb = _sm.Get(id);

            if (sizeInDb == null)
                return NotFound();


            var updatedSizeDto = Mapper.Map(sizeDto, sizeInDb);

            if (_sm.Update(id, updatedSizeDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Sizes/1
        [HttpDelete]
        public IHttpActionResult DeleteSize(int id)
        {
            var sizeInDb = _sm.Get(id);

            if (sizeInDb == null)
                return NotFound();

            if (_sm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
