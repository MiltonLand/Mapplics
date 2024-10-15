using MapplicsEjercicio2.Application.Commands;
using MapplicsEjercicio2.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio2.Application.Handlers
{
    public class InsertProductHandler : IRequestHandler<InsertProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public InsertProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.Create(request.Product);
        }
    }
}
