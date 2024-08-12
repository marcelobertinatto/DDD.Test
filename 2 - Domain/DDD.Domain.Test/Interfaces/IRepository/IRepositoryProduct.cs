using DDD.Domain.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Test.Interfaces.IRepository
{
    public interface IRepositoryProduct : IRepositoryBase<Product>
    {
        Task<Product> GetProductById(Guid Id);
        Task<Product> GetProductByName(string Name);
        void UpdateProduct(Product entity);
        void DeleteProduct(Product entity);
    }
}
