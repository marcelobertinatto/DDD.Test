using DDD.Domain.Test.Entities;

namespace DDD.Domain.Test.Interfaces.IService
{
    public interface IServiceProduct : IServiceBase<Product>
    {
        Task<Product> GetProductById(Guid Id);
        Task<Product> GetProductByName(string Name);
        void UpdateProduct(Product entity);
        void DeleteProduct(Product entity);
    }
}
