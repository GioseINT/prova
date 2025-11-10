using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prova.BLL.Interfaces;
using Prova.DAL.Interfaces;

namespace Prova.BLL.Services
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel, TEntity>
        where TModel : class
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TModel> GetAll()
        {
            var entities = _repository.GetAll();
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public TModel? GetById(int id)
        {
            if (id == 0)
            {
                throw new Exception("Invalid ID");
            }
            var entity = _repository.GetById(id);
            return entity == null ? null : _mapper.Map<TModel>(entity);
        }

        public void Add(TModel model)
        {
            if (model == null)
            {
                throw new Exception("Model cannot be null");
            }
            var entity = _mapper.Map<TEntity>(model);
            _repository.Add(entity);
            _repository.SaveChanges();
        }

        public void Update(TModel model)
        {
            if (model == null)
            {
                throw new Exception("Model cannot be null");
            }
            var entity = _mapper.Map<TEntity>(model);
            _repository.Update(entity);
            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            _repository.Remove(entity);
            _repository.SaveChanges();
        }
    }
}

