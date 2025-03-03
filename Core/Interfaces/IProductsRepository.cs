using Core.Models;

namespace Core.Interfaces
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Gets list of products in repository.
        /// </summary>
        Task<List<Product>> GetProducts();

        /// <summary>
        /// Gets list of products in repository by page.
        /// </summary>
        /// <param name="page">The page count.</param>
        /// <param name="pageSize">The page size.</param>
        Task<List<Product>> GetProductsPaged(int page, int pageSize);

        /// <summary>
        /// Gets product by unique item identifier.
        /// </summary>
        /// <param name="id">The unique item identifier</param>
        /// <returns></returns>
        Task<Product?> GetProductById(int id);

        /// <summary>
        /// Gets all products count.
        /// </summary>
        /// <returns></returns>
        Task<int> GetProductsCount();

        Task<bool> UpdateProduct(Product product);
    }
}
