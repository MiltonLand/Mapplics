using MapplicsEjercicio2.Application.Commands;
using MapplicsEjercicio2.Application.Queries;
using MapplicsEjercicio2.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product?> Get(int id)
        {
            return await _mediator.Send(new GetProductQuery(id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await _mediator.Send(new InsertProductCommand(product));
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task Put([FromBody] Product product)
        {
            await _mediator.Send(new UpdateProductCommand(product));
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete]
        public async Task Delete([FromBody] Product product)
        {
            await _mediator.Send(new DeleteProductCommand(product));
        }
    }
}
