using System.ComponentModel.DataAnnotations;
using Application.DataTransferObjects;
using Application.Interfaces;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<ProductsService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsService"/> class.
        /// </summary>
        /// <param name="repository">The products repository.</param>
        public ProductsService(IProductsRepository repository, IMapper mapper, ILogger<ProductsService> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Gets list of products in repository.
        /// </summary>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<List<ProductDTO>> GetProducts(CancellationToken cancellationToken)
        {
            List<Product> products = await this.repository.GetProducts(cancellationToken);
            return this.mapper.Map<IEnumerable<ProductDTO>>(products).ToList();
        }

        /// <summary>
        /// Gets products in repository by specified page.
        /// </summary>
        /// <param name="page">The page count.</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<PageResultDTO<ProductDTO>> GetProductsPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            List<Product> products = await this.repository.GetProductsPaged(page, pageSize, cancellationToken);
            List<ProductDTO> productDTOs = this.mapper.Map<IEnumerable<ProductDTO>>(products).ToList();

            int productsCount = await this.repository.GetProductsCount(cancellationToken);
            
            return new PageResultDTO<ProductDTO>(productDTOs, productsCount, pageSize);
        }

        /// <summary>
        /// Gets product with specified unique identifier.
        /// </summary>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<ProductDTO?> GetProduct(int id, CancellationToken cancellationToken)
        {
            Product? product = await this.repository.GetProductById(id, cancellationToken);

            if (product == null)
                return null;

            return this.mapper.Map<ProductDTO>(product);
        }

        /// <summary>
        /// Updates product's description.
        /// </summary>
        /// <param name="id">The product unique identifier.</param>
        /// <param name="description">The new description.</param>
        /// <param name="cancellationToken">The operation cancellation token.</param>
        public async Task<bool> UpdateProductDescription(int id, string? description, CancellationToken cancellationToken)
        {
            Product? product = await this.repository.GetProductById(id, cancellationToken);

            if (product == null)
            {
                this.logger.LogWarning($"Product with ID {id} not found.");
                return false;
            }

            product.Description = description;

            // Validate the updated product
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(product);
            if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
                throw new ValidationException(validationResults.First().ErrorMessage);

            return await this.repository.UpdateProduct(product, cancellationToken);
        }
    }
}
