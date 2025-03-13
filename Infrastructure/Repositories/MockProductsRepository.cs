using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MockProductsRepository : IProductsRepository
    {
        private readonly List<Product> products = InitialDataSeeder.GetProducts().ToList();

        /// <summary>
        /// Gets products stored in repository directly.
        /// </summary>
        public List<Product> Products => this.products;
        
        /// <summary>
        /// Gets list of products in repository.
        /// </summary>
        public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.products);
        }

        /// <summary>
        /// Gets list of products in repository by page.
        /// </summary>
        /// <param name="page">The page count.</param>
        /// <param name="pageSize">The page size.</param>
        public async Task<List<Product>> GetProductsPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList());
        }

        /// <summary>
        /// Gets product with specified unique identifier.
        /// </summary>
        public async Task<Product?> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.products.FirstOrDefault(x => x.Id == id));
        }

        /// <summary>
        /// Gets products count.
        /// </summary>
        public async Task<int> GetProductsCount(CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.products.Count);
        }

        /// <summary>
        /// Updates product's description.
        /// </summary>
        /// <param name="id">The product unique identifier.</param>
        /// <param name="description">The new description.</param>
        public async Task<bool> UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            Product? existingProduct = this.products.FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct == null)
                return false;

            existingProduct.Description = product.Description;
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Resets the data to its initial state.
        /// </summary>
        public void ResetData()
        {
            this.products.Clear();
            this.products.AddRange(InitialDataSeeder.GetProducts());
        }
    }
}
