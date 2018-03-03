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
    public class MaterialManager
    {
        private MaterialRepository _repository;

        public MaterialManager()
        {
            _repository = new MaterialRepository();
        }

        public MaterialDto Get(int id)
        {
            var materialInDb = _repository.Get(id);
            return Mapper.Map<Material, MaterialDto>(materialInDb);
        }

        public IEnumerable<MaterialDto> GetAll()
        {
            var materialInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Material>, IEnumerable<MaterialDto>>(materialInDb);
        }

        public IEnumerable<MaterialDto> Find(Expression<Func<MaterialDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<MaterialDto, bool>>, Expression<Func<Material, bool>>>(predicate);
            var materialInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Material>, IEnumerable<MaterialDto>>(materialInDb);
        }

        public bool Add(MaterialDto entity)
        {
            var mappedDto = Mapper.Map<MaterialDto, Material>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<MaterialDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<MaterialDto>, IEnumerable<Material>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, MaterialDto entity)
        {
            var mappedDto = Mapper.Map<MaterialDto, Material>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<MaterialDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<MaterialDto>, IEnumerable<Material>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
