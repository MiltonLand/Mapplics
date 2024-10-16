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
            Category c = _dbContext.Categories.FirstOrDefault(c => c.Id == product.Category.Id);

            if (c != null)
            {
                product.Category = c;
            }

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
            IEnumerable<Product> products =  await _dapperDataAccess.LoadData<Product, dynamic>("dbo.spProduct_GetAll", new { });

            IEnumerable<Category> categories =  await _dapperDataAccess.LoadData<Category, dynamic>("dbo.spCategory_GetAll", new { });

            foreach (var product in products)
            {
                product.Category = categories.Where(c => c.Id == product.CategoryId).FirstOrDefault();
            }

            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategory(int id)
        {
            IEnumerable<Product> products = await _dapperDataAccess.LoadData<Product, dynamic>("dbo.spProduct_GetAll", new { });

            var category = (await _dapperDataAccess.LoadData<Category, dynamic>("dbo.spCategory_Get", new { Id = id })).FirstOrDefault();

            List<Product> outputProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.CategoryId == id)
                {
                    product.Category = category;
                    outputProducts.Add(product);
                }
            }

            return outputProducts;
        }

        public async Task<Product?> Get(int id)
        {
            var results = await _dapperDataAccess.LoadData<Product, dynamic>("dbo.spProduct_Get", new { Id = id });

            IEnumerable<Category> categories = await _dapperDataAccess.LoadData<Category, dynamic>("dbo.spCategory_GetAll", new { });

            Product? product = results.FirstOrDefault();

            if (product != null)
            {
                var category = (await _dapperDataAccess.LoadData<Category, dynamic>("dbo.spCategory_Get", new { Id = product.CategoryId })).FirstOrDefault();

                product.Category = category;
            }

            return product;
        }

        public async Task Update(Product product)
        {
            Category c = _dbContext.Categories.FirstOrDefault(c => c.Id == product.Category.Id);

            if (c != null)
            {
                product.Category = c;
            }

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
