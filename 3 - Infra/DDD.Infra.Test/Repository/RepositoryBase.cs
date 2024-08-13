using DDD.Application.Test.Interfaces;
using DDD.Domain.Test.Interfaces.IRepository;
using DDD.Infra.Test.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Test.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ProjectDBContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(ProjectDBContext dBContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dBContext;
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _dbContext.AddAsync(entity);
            _unitOfWork.Commit();
        }

        public void AddAll(List<T> listEntities)
        {
            _dbContext.AddRangeAsync(listEntities);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _unitOfWork.Commit();
        }

        public void DeleteAll(List<T> listEntities)
        {
            _dbContext.RemoveRange(listEntities);
            _unitOfWork.Commit();
        }

        public async Task<T> Get(Guid Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();            
        }

        public void Update(T entity)
        {
            _dbContext.UpdateRange(entity);
            _unitOfWork.Commit();
        }

        public void UpdateAll(List<T> listEntities)
        {
            _dbContext.UpdateRange(listEntities);
            _unitOfWork.Commit();
        }
    }
}
