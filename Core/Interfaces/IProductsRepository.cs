using Core.Models;

namespace Core.Interfaces
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Gets list of products in repository.
        /// </summary>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<List<Product>> GetProducts(CancellationToken cancellationToken);

        /// <summary>
        /// Gets list of products in repository by page.
        /// </summary>
        /// <param name="page">The page count.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<List<Product>> GetProductsPaged(int page, int pageSize, CancellationToken cancellationToken);

        /// <summary>
        /// Gets product by unique item identifier.
        /// </summary>
        /// <param name="id">The unique item identifier</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<Product?> GetProductById(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets all products count.
        /// </summary>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<int> GetProductsCount(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<bool> UpdateProduct(Product product, CancellationToken cancellationToken);
    }
}
