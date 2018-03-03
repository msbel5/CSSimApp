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
    public class BouquetMaterialManager
    {
        private BouquetMaterialRepository _repository;

        public BouquetMaterialManager()
        {
            _repository = new BouquetMaterialRepository();
        }

        public BouquetMaterialDto Get(int id)
        {
            var bouquetMaterialInDb = _repository.Get(id);
            return Mapper.Map<BouquetMaterial, BouquetMaterialDto>(bouquetMaterialInDb);
        }

        public IEnumerable<BouquetMaterialDto> GetAll()
        {
            var bouquetMaterialInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<BouquetMaterial>, IEnumerable<BouquetMaterialDto>>(bouquetMaterialInDb);
        }

        public IEnumerable<BouquetMaterialDto> Find(Expression<Func<BouquetMaterialDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<BouquetMaterialDto, bool>>, Expression<Func<BouquetMaterial, bool>>>(predicate);
            var bouquetMaterialInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<BouquetMaterial>, IEnumerable<BouquetMaterialDto>>(bouquetMaterialInDb);
        }

        public bool Add(BouquetMaterialDto entity)
        {
            var mappedDto = Mapper.Map<BouquetMaterialDto, BouquetMaterial>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<BouquetMaterialDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<BouquetMaterialDto>, IEnumerable<BouquetMaterial>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, BouquetMaterialDto entity)
        {
            var mappedDto = Mapper.Map<BouquetMaterialDto, BouquetMaterial>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<BouquetMaterialDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<BouquetMaterialDto>, IEnumerable<BouquetMaterial>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
