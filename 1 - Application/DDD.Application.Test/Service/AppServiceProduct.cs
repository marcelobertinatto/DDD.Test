using DDD.Application.Test.Interfaces.Services;
using DDD.Domain.Test.Entities;
using DDD.Domain.Test.Interfaces.IService;

namespace DDD.Application.Test.Service
{
    public class AppServiceProduct : AppServiceBase<Product>, IAppServiceProduct
    {
        private IServiceProduct _serviceProduct;
        public AppServiceProduct(IServiceProduct serviceProduct) 
            : base(serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }

        public void DeleteProduct(Product entity)
        {
            _serviceProduct.DeleteProduct(entity);
        }

        public async Task<Product> GetProductById(Guid Id)
        {
            return await _serviceProduct.GetProductById(Id);
        }

        public async Task<Product> GetProductByName(string Name)
        {
            return await _serviceProduct.GetProductByName(Name);
        }

        public void UpdateProduct(Product entity)
        {
            _serviceProduct.UpdateProduct(entity);
        }
    }
}
