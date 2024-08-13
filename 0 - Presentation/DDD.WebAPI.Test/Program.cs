using DDD.Application.Test.Interfaces;
using DDD.Application.Test.Interfaces.Services;
using DDD.Application.Test.Service;
using DDD.Domain.Test.Interfaces.IRepository;
using DDD.Domain.Test.Interfaces.IService;
using DDD.Domain.Test.Services;
using DDD.Infra.Test.Context;
using DDD.Infra.Test.Repository;
using DDD.Infra.Test.Transaction;
using DDD.WebAPI.Test.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DDD.WebAPI.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Db
            builder.Services.AddDbContext<ProjectDBContext>(opt => opt.UseInMemoryDatabase("CatalogProduct"));

            //DI mapping
            //Services
            builder.Services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            builder.Services.AddTransient(typeof(IAppServiceProduct), typeof(AppServiceProduct));
            builder.Services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            builder.Services.AddTransient(typeof(IServiceProduct), typeof(ServiceProduct));

            //Repository
            builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            builder.Services.AddTransient<IRepositoryProduct, RepositoryProduct>();

            //UnitOfWork
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            //AutoMapper Config
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            var app = builder.Build();            

            app.Run();
        }
    }
}
