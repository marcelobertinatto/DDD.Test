using DDD.Domain.Test.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Test.Context
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext()
        {
                
        }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
        {
                
        }

        public virtual DbSet<Product> Products { get; set; }

        
    }
}
