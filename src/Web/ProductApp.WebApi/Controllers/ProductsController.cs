using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Commands.CreateProduct;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Features.Queries.GetProductById;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var query = new GetAllProductQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}
