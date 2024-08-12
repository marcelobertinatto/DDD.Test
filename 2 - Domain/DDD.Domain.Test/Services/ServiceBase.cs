using DDD.Domain.Test.Interfaces.IRepository;
using DDD.Domain.Test.Interfaces.IService;

namespace DDD.Domain.Test.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase) 
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(T entity)
        {
            _repositoryBase.Add(entity);
        }

        public void AddAll(List<T> listEntities)
        {
            _repositoryBase.AddAll(listEntities);
        }

        public void Delete(T entity)
        {
            _repositoryBase.Delete(entity);
        }

        public void DeleteAll(List<T> listEntities)
        {
            _repositoryBase.DeleteAll(listEntities);
        }

        public Task<T> Get(Guid Id)
        {
            return _repositoryBase.Get(Id);
        }

        public Task<List<T>> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public void Update(T entity)
        {
            _repositoryBase.Update(entity);
        }

        public void UpdateAll(List<T> listEntities)
        {
            _repositoryBase.UpdateAll(listEntities);
        }
    }
}
