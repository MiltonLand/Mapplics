using MapplicsEjercicio2.Domain.Entities;
using MapplicsEjercicio2.Domain.Interfaces;
using MapplicsEjercicio2.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio2.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IDapperDataAccess _dapperDataAccess;

        public CategoryRepository(AppDbContext dbContext, IDapperDataAccess dapperDataAccess)
        {
            _dbContext = dbContext;
            _dapperDataAccess = dapperDataAccess;
        }

        public async Task Create(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category> Create2(string name, string description)
        {
            Category category = new() { Name = name, Description = description };
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task Delete(Category category)
        {
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _dapperDataAccess.LoadData<Category, dynamic>("dbo.spCategory_GetAll", new { });
        }

        public async Task<Category?> Get(int id)
        {
            var results = await _dapperDataAccess.LoadData<Category, dynamic>("dbo.spCategory_Get", new { Id = id });

            return results.FirstOrDefault();
        }

        public async Task Update(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
