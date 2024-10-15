using MapplicsEjercicio2.Application.Commands;
using MapplicsEjercicio2.Domain.Entities;
using MapplicsEjercicio2.Domain.Interfaces;
using MediatR;

namespace MapplicsEjercicio2.Application.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.Update(request.Category);
        }
    }
}
