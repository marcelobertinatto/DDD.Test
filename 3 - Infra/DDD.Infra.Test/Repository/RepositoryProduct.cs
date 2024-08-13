using DDD.Application.Test.Interfaces;
using DDD.Domain.Test.Entities;
using DDD.Domain.Test.Interfaces.IRepository;
using DDD.Infra.Test.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Test.Repository
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        private readonly ProjectDBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryProduct(ProjectDBContext projectDBContext, IUnitOfWork unitOfWork) 
            : base(projectDBContext, unitOfWork)
        {
            _context = projectDBContext;
            _unitOfWork = unitOfWork;
        }

        public void DeleteProduct(Product entity)
        {
            _context.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<Product> GetProductById(Guid Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public async Task<Product> GetProductByName(string Name)
        {
            return await _context.Products.Where(x => x.Name.Contains(Name)).FirstOrDefaultAsync();
        }

        public void UpdateProduct(Product entity)
        {
            _context.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
