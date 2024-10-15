using MapplicsEjercicio2.Application.Queries;
using MapplicsEjercicio2.Domain.Entities;
using MapplicsEjercicio2.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio2.Application.Handlers
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, Category?>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Get(request.Id);
        }
    }
}
