using Application.DataTransferObjects;
using Core.Models;

namespace Application.Interfaces
{
    public interface IProductsService
    {
        /// <summary>
        /// Gets list of products in repository.
        /// </summary>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<List<ProductDTO>> GetProducts(CancellationToken cancellationToken);

        /// <summary>
        /// Gets products in repository by specified page.
        /// </summary>
        /// <param name="page">The page count.</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<PaginatedList<ProductDTO>> GetProductsPaged(int page, int pageSize, CancellationToken cancellationToken);

        /// <summary>
        /// Gets product with specified unique identifier.
        /// </summary>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<ProductDTO?> GetProduct(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Updates product's description.
        /// </summary>
        /// <param name="id">The product unique identifier.</param>
        /// <param name="description">The new description.</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        Task<bool> UpdateProductDescription(int id, string? description, CancellationToken cancellationToken);
    }
}
