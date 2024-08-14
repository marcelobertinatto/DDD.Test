using AutoMapper;
using DDD.Domain.Test.Entities;
using DDD.WebAPI.Test.Model;

namespace DDD.WebAPI.Test.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductViewModel,Product>();
        }
    }
}
