using MapplicsEjercicio2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio2.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product?> Get(int id);
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
