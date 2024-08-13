using DDD.Application.Test.Interfaces;
using DDD.Infra.Test.Context;

namespace DDD.Infra.Test.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectDBContext _dbContext;

        public UnitOfWork(ProjectDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void Commit()
        {
            _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
