using DDD.Domain.Test.Entities;
using DDD.Domain.Test.Interfaces.IRepository;
using DDD.Domain.Test.Interfaces.IService;

namespace DDD.Domain.Test.Services
{
    public class ServiceProduct : ServiceBase<Product>, IServiceProduct<Product>
    {
        private IRepositoryProduct _repositoryProduct;
        public ServiceProduct(IRepositoryProduct repositoryProduct) : base(repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public void DeleteProduct(Product entity)
        {
            _repositoryProduct.DeleteProduct(entity);
        }

        public async Task<Product> GetProductById(Guid Id)
        {
            return await _repositoryProduct.GetProductById(Id);
        }

        public async Task<Product> GetProductByName(string Name)
        {
            return await _repositoryProduct.GetProductByName(Name);
        }

        public void UpdateProduct(Product entity)
        {
            _repositoryProduct.UpdateProduct(entity);
        }
    }
}
