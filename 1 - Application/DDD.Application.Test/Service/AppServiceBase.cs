using DDD.Application.Test.Interfaces.Services;
using DDD.Domain.Test.Interfaces.IService;

namespace DDD.Application.Test.Service
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        private IServiceBase<T> _serviceBase;
        public AppServiceBase(IServiceBase<T> serviceBase) 
        { 
            _serviceBase = serviceBase;
        }

        public void Add(T entity)
        {
            _serviceBase.Add(entity);
        }

        public void AddAll(List<T> listEntities)
        {
            _serviceBase.AddAll(listEntities);
        }

        public void Delete(T entity)
        {
            _serviceBase.Delete(entity);
        }

        public void DeleteAll(List<T> listEntities)
        {
            _serviceBase.DeleteAll(listEntities);
        }

        public async Task<T> Get(Guid Id)
        {
            return await _serviceBase.Get(Id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _serviceBase.GetAll();
        }

        public void Update(T entity)
        {
            _serviceBase.Update(entity);
        }

        public void UpdateAll(List<T> listEntities)
        {
            _serviceBase.UpdateAll(listEntities);
        }
    }
}
