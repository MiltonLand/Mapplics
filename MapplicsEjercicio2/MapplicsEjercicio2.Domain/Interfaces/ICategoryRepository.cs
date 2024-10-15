using MapplicsEjercicio2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio2.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
        Task<Category?> Get(int id);
        Task Create(Category category);
        Task<Category> Create2(string name, string desc);
        Task Update(Category category);
        Task Delete(Category category);

    }
}
