using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSSimApp.BLL.Dtos;
using CSSimApp.DAL.Models;
using CSSimApp.DAL.Repositories;

namespace CSSimApp.BLL.Services
{
    public class BouquetManager
    {
        private BouquetRepository _repository;

        public BouquetManager()
        {
            _repository = new BouquetRepository();
        }

        public BouquetDto Get(int id)
        {
            var bouquetInDb = _repository.Get(id);
            return Mapper.Map<Bouquet, BouquetDto>(bouquetInDb);
        }

        public IEnumerable<BouquetDto> GetAll()
        {
            var bouquetInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Bouquet>, IEnumerable<BouquetDto>>(bouquetInDb);
        }

        public IEnumerable<BouquetDto> EagerGetAll()
        {
            var bouquetInDb = _repository.EagerGetAll();
            return Mapper.Map<IEnumerable<Bouquet>, IEnumerable<BouquetDto>>(bouquetInDb);
        }

        public IEnumerable<BouquetDto> Find(Expression<Func<BouquetDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<BouquetDto, bool>>, Expression<Func<Bouquet, bool>>>(predicate);
            var bouquetInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Bouquet>, IEnumerable<BouquetDto>>(bouquetInDb);
        }

        public bool Add(BouquetDto entity)
        {
            //var mappedDto = Mapper.Map<BouquetDto, Bouquet>(entity);
            var bMaterials = new List<BouquetMaterial>();

            foreach (BouquetMaterialDto bouquetMaterialDto in entity.Materials)
            {
                BouquetMaterial bMaterial = new BouquetMaterial
                {
                    Quantity = bouquetMaterialDto.Quantity,
                    MaterialId = bouquetMaterialDto.MaterialId,
                };
                bMaterials.Add(bMaterial);
            }

            Bouquet bouquet = new Bouquet
            {
                Name = entity.Name,
                Materials = bMaterials,
                SizeId = entity.SizeId,
                Price = entity.Price
            };
            return _repository.Add(bouquet);
        }

        public bool AddRange(IEnumerable<BouquetDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<BouquetDto>, IEnumerable<Bouquet>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, BouquetDto entity)
        {
            var mappedDto = Mapper.Map<BouquetDto, Bouquet>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<BouquetDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<BouquetDto>, IEnumerable<Bouquet>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
