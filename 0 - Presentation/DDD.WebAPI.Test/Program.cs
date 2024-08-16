using System.Reflection;
using AutoMapper;
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
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace DDD.WebAPI.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //adding a call for Controllers
            builder.Services.AddControllers();

            //Db
            builder.Services.AddDbContext<ProjectDBContext>(opt => opt.UseInMemoryDatabase("CatalogProduct"));

            //DI mapping
            //Services
            builder.Services.TryAddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            builder.Services.TryAddTransient(typeof(IAppServiceProduct), typeof(AppServiceProduct));
            builder.Services.TryAddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            builder.Services.TryAddTransient(typeof(IServiceProduct), typeof(ServiceProduct));

            //Repository
            builder.Services.TryAddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            builder.Services.TryAddTransient<IRepositoryProduct, RepositoryProduct>();

            //UnitOfWork
            builder.Services.TryAddTransient<IUnitOfWork, UnitOfWork>();

            //AutoMapper Config
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            //CORS
            builder.Services.AddCors(opt =>
            {
                //Web Api Policy
                opt.AddPolicy("WebAPI.Test", policyBuilder =>
                {
                    policyBuilder.WithOrigins("https://localhost:7112");
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.AllowCredentials();
                });

                //Angular App
                opt.AddPolicy("AngularUI", policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:4200");
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.AllowCredentials();
                });
            });

            //Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDD.WebApi", Version = "v1" });                
            });

            var app = builder.Build();

            app.MapControllers();

            app.UseHttpsRedirection();

            app.UseStaticFiles(); 
            app.UseRouting(); 

            app.UseAuthorization();

            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AngularUI");

            app.Run();

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("swagger/v1/swagger.json", "DDD.WebApi V1");
                opt.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
            });
        }
    }
}
