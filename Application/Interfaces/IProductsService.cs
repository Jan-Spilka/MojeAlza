using Application.DataTransferObjects;

namespace Application.Interfaces
{
    public interface IProductsService
    {
        /// <summary>
        /// Gets list of products in repository.
        /// </summary>
        Task<List<ProductDTO>> GetProducts();

        /// <summary>
        /// Gets products in repository by specified page.
        /// </summary>
        /// <param name="page">The page count.</param>
        /// <param name="pageSize">The page size</param>
        /// <returns></returns>
        Task<PageResultDTO<ProductDTO>> GetProductsPaged(int page, int pageSize);

        /// <summary>
        /// Gets product with specified unique identifier.
        /// </summary>
        Task<ProductDTO?> GetProduct(int id);

        /// <summary>
        /// Updates product's description.
        /// </summary>
        /// <param name="id">The product unique identifier.</param>
        /// <param name="description">The new description.</param>
        Task<bool> UpdateProductDescription(int id, string? description);
    }
}
