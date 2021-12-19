using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allList = await _productRepository.GetAllAsync();
            // burada alllist product entity dönüyor. api den domaine erişmiş oluyoruz. erişim olmaması daha güzel olur.

            var result = allList.Select(x => new ProductViewDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(result);
        }

    }
}
