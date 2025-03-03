using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ProductsRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets list of products in repository.
        /// </summary>
        public async Task<List<Product>> GetProducts()
        {
            return await this.context.Products.ToListAsync();
        }

        /// <summary>
        /// Gets list of products in repository by page.
        /// </summary>
        /// <param name="page">The page count.</param>
        /// <param name="pageSize">The page size.</param>
        public async Task<List<Product>> GetProductsPaged(int page, int pageSize)
        {
            return await this.context.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Gets product by item unique identifier.
        /// </summary>
        /// <param name="id">The item unique identifier.</param>
        public async Task<Product?> GetProductById(int id)
        {
            return await this.context.Products.FindAsync(id);
        }

        /// <summary>
        /// Gets products count.
        /// </summary>
        public async Task<int> GetProductsCount()
        {
            return await this.context.Products.CountAsync();
        }

        /// <summary>
        /// Updates product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public async Task<bool> UpdateProduct(Product product)
        {
            this.context.Products.Update(product);
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
