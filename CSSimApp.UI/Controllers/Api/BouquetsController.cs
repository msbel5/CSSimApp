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
    public class BouquetsController : ApiController
    {
        private BouquetManager _bm;

        public BouquetsController()
        {
            _bm = new BouquetManager();
        }
        // GET /api/Bouquets
        public IHttpActionResult GetBouquets()
        {
            var bouquetDtos = _bm.GetAll();

            return Ok(bouquetDtos);
        }

        // GET /api/Bouquets/1

        public IHttpActionResult GetBouquet(int id)
        {
            var bouquetDto = _bm.Get(id);
            if (bouquetDto == null)
                return NotFound();
            return Ok(bouquetDto);
        }

        // POST /api/Bouquets
        [HttpPost]
        public IHttpActionResult CreateBouquet(BouquetDto bouquetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_bm.Add(bouquetDto))
            {
                bouquetDto.Id = bouquetDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + bouquetDto.Id), bouquetDto);
            }
            return BadRequest();

        }


        // PUT /api/Bouquets/1
        [HttpPut]
        public IHttpActionResult UpdateBouquet(int id, BouquetDto bouquetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var BouquetInDb = _bm.Get(id);

            if (BouquetInDb == null)
                return NotFound();


            var updatedBouquetDto = Mapper.Map(bouquetDto, BouquetInDb);

            if (_bm.Update(id, updatedBouquetDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Bouquets/1
        [HttpDelete]
        public IHttpActionResult DeleteBouquet(int id)
        {
            var bouquetInDb = _bm.Get(id);

            if (bouquetInDb == null)
                return NotFound();

            if (_bm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
