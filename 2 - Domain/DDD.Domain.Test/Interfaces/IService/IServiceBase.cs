namespace DDD.Domain.Test.Interfaces.IService
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T entity);
        void AddAll(List<T> listEntities);
        void Update(T entity);
        void UpdateAll(List<T> listEntities);
        void Delete(T entity);
        void DeleteAll(List<T> listEntities);
        Task<T> Get(Guid Id);
        Task<List<T>> GetAll();
    }
}
