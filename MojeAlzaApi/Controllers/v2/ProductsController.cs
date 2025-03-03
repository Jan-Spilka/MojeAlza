using Application.DataTransferObjects;
using Application.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
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
        /// Get all products using paging.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PageResultDTO<ProductDTO>>> GetProducts(int page = 1, int pageSize = 10)
        {
            if (page < 1 || pageSize < 1)
                return this.BadRequest("Page and PageSize must be greater than 0.");

            PageResultDTO<ProductDTO> productsPaged = await this.productsService.GetProductsPaged(page, pageSize);
            return this.Ok(productsPaged);
        }
    }
}
