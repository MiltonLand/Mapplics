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
    public class GetAllProductsByCategoryHandler : IRequestHandler<GetAllProductsByCategoryQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsByCategoryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProductsByCategory(request.Id);
        }
    }
}
