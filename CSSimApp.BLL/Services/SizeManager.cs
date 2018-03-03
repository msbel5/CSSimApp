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
    public class SizeManager
    {
        private SizeRepository _repository;

        public SizeManager()
        {
            _repository = new SizeRepository();
        }

        public SizeDto Get(int id)
        {
            var sizeInDb = _repository.Get(id);
            return Mapper.Map<Size, SizeDto>(sizeInDb);
        }

        public IEnumerable<SizeDto> GetAll()
        {
            var sizeInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Size>, IEnumerable<SizeDto>>(sizeInDb);
        }

        public IEnumerable<SizeDto> Find(Expression<Func<SizeDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<SizeDto, bool>>, Expression<Func<Size, bool>>>(predicate);
            var sizeInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Size>, IEnumerable<SizeDto>>(sizeInDb);
        }

        public bool Add(SizeDto entity)
        {
            var mappedDto = Mapper.Map<SizeDto, Size>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<SizeDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<SizeDto>, IEnumerable<Size>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, SizeDto entity)
        {
            var mappedDto = Mapper.Map<SizeDto, Size>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<SizeDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<SizeDto>, IEnumerable<Size>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
