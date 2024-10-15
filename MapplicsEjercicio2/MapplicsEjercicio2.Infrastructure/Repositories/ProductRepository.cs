using MapplicsEjercicio2.Domain.Entities;
using MapplicsEjercicio2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio2.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IDapperDataAccess _dapperDataAccess;

        public ProductRepository(AppDbContext dbContext, IDapperDataAccess dapperDataAccess)
        {
            _dbContext = dbContext;
            _dapperDataAccess = dapperDataAccess;
        }

        public async Task Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _dapperDataAccess.LoadData<Product, dynamic>("dbo.spProduct_GetAll", new { });
        }

        public async Task<Product?> Get(int id)
        {
            var results = await _dapperDataAccess.LoadData<Product, dynamic>("dbo.spProduct_Get", new { Id = id });

            return results.FirstOrDefault();
        }

        public async Task Update(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
