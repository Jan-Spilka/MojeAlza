﻿using Application.DataTransferObjects;
using Application.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The products service.</param>
        public ProductsController(IProductsService productService)
        {
            this.productsService = productService;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            List<ProductDTO> products = await this.productsService.GetProducts();
            return this.Ok(products);
        }

        /// <summary>
        /// Gets product with specified unique identifier.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            ProductDTO? product = await this.productsService.GetProduct(id);

            if (product == null)
                return this.NotFound(new { Message = $"Product with ID '{id}' not found" });

            return this.Ok(product);
        }

        /// <summary>
        /// Updates product's description.
        /// </summary>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] ProductDescriptionDTO dto)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            bool success = await this.productsService.UpdateProductDescription(id, dto.Description);

            if (!success)
                return this.NotFound();

            return this.NoContent();
        }
    }
}
