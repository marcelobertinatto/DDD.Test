namespace DDD.Application.Test.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
