using DDD.Domain.Test.Entities;

namespace DDD.Application.Test.Interfaces.Services
{
    public interface IAppServiceProduct : IAppServiceBase<Product>
    {
        Task<Product> GetProductById(Guid Id);
        Task<Product> GetProductByName(string Name);
        void UpdateProduct(Product entity);
        void DeleteProduct(Product entity);
    }
}
