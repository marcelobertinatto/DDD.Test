using AutoMapper;
using DDD.Application.Test.Interfaces.Services;
using DDD.WebAPI.Test.AutoMapper;
using DDD.WebAPI.Test.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.WebAPI.Test.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAppServiceProduct _appServiceProduct;
        private readonly IMapper _mapper;
        public ProductController(IAppServiceProduct appServiceProduct, IMapper mapper)
        {
            _appServiceProduct = appServiceProduct;
            mapper = _mapper;
        }

        [HttpPost]
        [Route("api/registerproduct")]
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

        [HttpGet]
        [Route("api/getproduct/{id}")]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
