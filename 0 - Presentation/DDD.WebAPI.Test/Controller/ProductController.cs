using AutoMapper;
using DDD.Application.Test.Interfaces.Services;
using DDD.WebAPI.Test.AutoMapper;
using DDD.WebAPI.Test.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.WebAPI.Test.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAppServiceProduct _appServiceProduct;
        private readonly IMapper _mapper;

        public ProductController(IAppServiceProduct appServiceProduct, IMapper mapper)
        {
            _appServiceProduct = appServiceProduct;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("registerproduct")]
        public async Task<IActionResult> RegisterProduct(ProductViewModel product) 
        {
            try
            {
                var p = _mapper.Map<DDD.Domain.Test.Entities.Product>(product);
                 _appServiceProduct.Add(p);

                return Ok("Registered!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("registerallproducts")]
        public async Task<IActionResult> RegisterAllProducts(List<ProductViewModel> products)
        {
            try
            {
                var p = _mapper.Map<List<DDD.Domain.Test.Entities.Product>>(products);
                _appServiceProduct.AddAll(p);

                return Ok("Registered!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getproduct/{Id}")]
        public async Task<IActionResult> GetProduct(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    var result = await _appServiceProduct.Get(Id);

                    return Ok(result);
                }
                return NotFound("Invalid Id!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {                
                var result = await _appServiceProduct.GetAll();

                if (result == null)
                {
                    return NotFound("Nothing Found!");
                }

                return Ok(result);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
