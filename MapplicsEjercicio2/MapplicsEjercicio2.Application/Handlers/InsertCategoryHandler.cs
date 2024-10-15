using MapplicsEjercicio2.Application.Commands;
using MapplicsEjercicio2.Domain.Entities;
using MapplicsEjercicio2.Domain.Interfaces;
using MediatR;

namespace MapplicsEjercicio2.Application.Handlers
{
    public class InsertCategoryHandler : IRequestHandler<InsertCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public InsertCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Create2(request.Name, request.Description);
        }
    }
}
