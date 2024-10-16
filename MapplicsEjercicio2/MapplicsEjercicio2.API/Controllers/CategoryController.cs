using MapplicsEjercicio2.Application.Commands;
using MapplicsEjercicio2.Application.Queries;
using MapplicsEjercicio2.Domain.Entities;
using MapplicsEjercicio2.Domain.Interfaces;
using MapplicsEjercicio2.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MapplicsEjercicio2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _mediator.Send(new GetAllCategoryQuery());
        }

        [HttpGet("{id}")]
        public async Task<Category?> Get(int id)
        {
            return await _mediator.Send(new GetCategoryQuery(id));
        }

        [HttpPost]
        public async Task<Category> Post(string name, string desc)
        {
            return await _mediator.Send(new InsertCategoryCommand(name, desc));
        }

        [HttpPut]
        public async Task Put([FromBody] Category category)
        {
            await _mediator.Send(new UpdateCategoryCommand(category));
        }

        [HttpDelete]
        public async Task Delete([FromBody] Category category)
        {
            await _mediator.Send(new DeleteCategoryCommand(category));
        }
    }
}
