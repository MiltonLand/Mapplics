using MapplicsEjercicio2.Application.Commands;
using MapplicsEjercicio2.Application.Queries;
using MapplicsEjercicio2.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MapplicsEjercicio2.API.Controllers
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
        public async Task<IEnumerable<Product>> Get()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }

        [HttpGet("byCategory/{categoryId}")]
        public async Task<IEnumerable<Product>> GetAllProductsByCategory(int categoryId)
        {
            return await _mediator.Send(new GetAllProductsByCategoryQuery(categoryId));
        }

        [HttpGet("{id}")]
        public async Task<Product?> Get(int id)
        {
            return await _mediator.Send(new GetProductQuery(id));
        }

        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await _mediator.Send(new InsertProductCommand(product));
        }

        [HttpPut]
        public async Task Put([FromBody] Product product)
        {
            await _mediator.Send(new UpdateProductCommand(product));
        }

        [HttpDelete]
        public async Task Delete([FromBody] Product product)
        {
            await _mediator.Send(new DeleteProductCommand(product));
        }
    }
}
