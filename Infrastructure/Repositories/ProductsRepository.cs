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
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await this.context.Products.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets list of products in repository by page.
        /// </summary>
        /// <param name="page">The page count.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<List<Product>> GetProductsPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await this.context.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets product by item unique identifier.
        /// </summary>
        /// <param name="id">The item unique identifier.</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<Product?> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await this.context.Products.FindAsync(id);
        }

        /// <summary>
        /// Gets products count.
        /// </summary>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<int> GetProductsCount(CancellationToken cancellationToken)
        {
            return await this.context.Products.CountAsync(cancellationToken);
        }

        /// <summary>
        /// Updates product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<bool> UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            this.context.Products.Update(product);
            return await this.context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
