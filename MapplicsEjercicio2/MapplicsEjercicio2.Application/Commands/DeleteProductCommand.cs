using MapplicsEjercicio2.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio2.Application.Commands
{
    public record DeleteProductCommand(Product Product) : IRequest;
}
