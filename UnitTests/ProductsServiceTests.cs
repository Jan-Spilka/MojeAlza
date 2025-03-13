using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using AutoMapper;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests
{
    public class ProductsServiceTests
    {
        private Mock<ILogger<ProductsService>> mockLogger;
        private ProductsService service;
        private MockProductsRepository repository;

        private event EventHandler<LogMessage>? Log;

        [SetUp]
        public void Setup()
        {
            this.repository = new MockProductsRepository();

            this.mockLogger = new Mock<ILogger<ProductsService>>();

            IMapper mockMapper = new MapperConfiguration((IMapperConfigurationExpression expression) => expression.AddProfile(new MappingProfile()))
                .CreateMapper();

            mockLogger.Setup(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.Is<It.IsAnyType>((v, _) => true), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()))
                .Callback((LogLevel level, EventId _, object states, Exception? _, Delegate _) =>
            {
                foreach (KeyValuePair<string, object?> state in (IReadOnlyList<KeyValuePair<string, object?>>)states)
                {
                    if (state.Value is not string stringValue)
                        continue;

                    this.Log?.Invoke(this, new LogMessage(level, stringValue));
                }
            });

            this.service = new ProductsService(repository, mockMapper, this.mockLogger.Object);
        }

        [Test]
        public async Task GetProduct_ShouldReturnCorrectProduct()
        {
            // For bigger data samples, we probably would want to specify just some Ids to check
            foreach (Product expectedProduct in InitialDataSeeder.GetProducts())
            {
                ProductDTO? actualProduct = await this.service.GetProduct(expectedProduct.Id, CancellationToken.None);

                Assert.That(actualProduct, Is.Not.Null, "Product was not found.");
                CheckProductData(actualProduct, expectedProduct);
            }
        }

        [Test]
        public async Task GetProduct_ShouldReturnNoProduct()
        {
            ProductDTO? nonExistentProduct = await this.service.GetProduct(-1, CancellationToken.None);
            Assert.That(nonExistentProduct, Is.Null, "Product with ID = -1 should not be found.");
        }

        [Test]
        public async Task GetProductsPaged_ShouldReturnCorrectProducts()
        {
            int page = 5;
            int pageSize = 7;

            PaginatedList<ProductDTO> productsPaginatedList = await this.service.GetProductsPaged(page, pageSize, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(productsPaginatedList, Is.Not.Null, "Page result should not be null.");
                Assert.That(productsPaginatedList.Count, Is.EqualTo(7), "Items count does not match.");
                Assert.That(productsPaginatedList.PagesCount, Is.EqualTo(8), "Pages count does not match.");
                Assert.That(productsPaginatedList.ItemsCountTotal, Is.EqualTo(50), "Items total count does not match.");
            });

            IEnumerable<Product> expectedProducts = InitialDataSeeder.GetProducts()
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            int i = 0;
            foreach (Product expectedProduct in expectedProducts)
            {
                ProductDTO actualProduct = productsPaginatedList[i];

                Assert.That(productsPaginatedList[i].Id, Is.EqualTo(expectedProduct.Id),
                    $"Expected product with ID = '{expectedProduct.Id}' in list of products, there is product with ID = '{actualProduct.Id}' instead.");

                CheckProductData(actualProduct, expectedProduct);
                i++;
            }
        }

        [Test]
        public async Task GetProductsPaged_ShouldReturnNoProducts()
        {
            int pageIndex = 10;
            int pageSize = 6;

            PaginatedList<ProductDTO> productsPaginatedList = await this.service.GetProductsPaged(pageIndex, pageSize, CancellationToken.None);

            Assert.That(productsPaginatedList, Is.Not.Null, "Page result should not be null.");
            Assert.Multiple(() =>
            {
                Assert.That(productsPaginatedList.Count, Is.EqualTo(0), $"There should be no products given for page index {pageIndex} when page size equals to {pageSize}.");
                Assert.That(productsPaginatedList.PageIndex, Is.EqualTo(pageIndex), "Page index should not match.");
                Assert.That(productsPaginatedList.PagesCount, Is.EqualTo(9), "Pages count does not match.");
                Assert.That(productsPaginatedList.ItemsCountTotal, Is.EqualTo(50), "Items total count does not match.");
            });
        }

        [Test]
        public async Task GetProductsPaged_ShouldReturnTruncatedProducts()
        {
            int pageIndex = 9;
            int pageSize = 6;

            PaginatedList<ProductDTO> productsPaginatedList = await this.service.GetProductsPaged(pageIndex, pageSize, CancellationToken.None);

            Assert.That(productsPaginatedList, Is.Not.Null, "Page result should not be null.");
            Assert.Multiple(() =>
            {
                Assert.That(productsPaginatedList.ItemsCountTotal, Is.EqualTo(50), "Items total count does not match.");
                Assert.That(productsPaginatedList.Count, Is.EqualTo(2), $"There should be 2 products given for page {pageIndex} when page size equals to {pageSize}.");
                Assert.That(productsPaginatedList.PageIndex, Is.EqualTo(pageIndex), "Page index should not match.");
                Assert.That(productsPaginatedList.PagesCount, Is.EqualTo(9), "Pages count does not match.");
                Assert.That(productsPaginatedList.HasPreviousPage, Is.EqualTo(true), "List should indicates that it has previous pages.");
                Assert.That(productsPaginatedList.HasNextPage, Is.EqualTo(false), "List should indicates that it does not have following pages.");
            });

            IEnumerable<Product> expectedProducts = InitialDataSeeder.GetProducts().TakeLast(2);

            int i = 0;
            foreach (Product expectedProduct in expectedProducts)
            {
                ProductDTO actualProduct = productsPaginatedList[i];

                Assert.That(actualProduct.Id, Is.EqualTo(expectedProduct.Id),
                    $"Expected product with ID = '{expectedProduct.Id}' in list of products, there is product with ID = '{actualProduct.Id}' instead.");

                CheckProductData(actualProduct, expectedProduct);
                i++;
            }
        }

        [Test]
        public async Task GetProducts_ShouldReturnAllProducts()
        {
            List<ProductDTO> products = await this.service.GetProducts(CancellationToken.None);
            Product[] expectedProducts = InitialDataSeeder.GetProducts();

            Assert.That(products.Count, Is.EqualTo(expectedProducts.Length), "Products count does not match.");

            // We can check all data with CheckProductData, but lets check just ID for now
            for (int i = 0; i < expectedProducts.Length; i++)
            {
                Product expectedProduct = expectedProducts[i];
                ProductDTO actualProduct = products[i];

                Assert.That(expectedProduct.Id, Is.EqualTo(actualProduct.Id),
                    $"Expected product with ID = '{expectedProduct.Id}' in list of products, there is product with ID = '{actualProduct.Id}' instead.");
            }
        }

        [Test]
        public async Task UpdateProductDescription_ShouldSucceed()
        {
            int productId = 33;
            string newDescription = "NEW DESCRIPTION TEST";

            try
            {
                bool updateDescriptionResult = await this.service.UpdateProductDescription(productId, newDescription, CancellationToken.None);
                Assert.That(updateDescriptionResult, Is.True, "Expected UpdateProductDescription to return true, indicating a successful update.");

                Product updatedProduct = this.repository.Products.Single(x => x.Id == productId);
                Assert.That(updatedProduct.Description, Is.EqualTo(newDescription), "Product description was not updated.");
            }
            finally
            {
                this.repository.ResetData();
            }
        }

        [Test]
        public async Task UpdateProductDescription_ShouldFailed()
        {
            int productId = -1;
            bool warningLogWritten = false;

            try
            {
                void OnMessageLog(LogMessage logMessage)
                {
                    if (logMessage.LogLevel != LogLevel.Warning)
                        return;

                    if (logMessage.Message != $"Product with ID {productId} not found.")
                        return;

                    warningLogWritten = true;
                }

                bool updateDescriptionResult = await WithLogMessageHandling(() => this.service.UpdateProductDescription(productId, "Test", CancellationToken.None), OnMessageLog);

                Assert.That(updateDescriptionResult, Is.False, "Expected UpdateProductDescription to return false, indicating that update operation could not be done.");
                Assert.That(warningLogWritten, Is.True, "Warning message was not logged.");
            }
            finally
            {
                this.repository.ResetData();
            }

            // Check if warning has been logged

        }

        private static void CheckProductData(ProductDTO product, Product expectedProductData)
        {
            Assert.Multiple(() =>
            {
                Assert.That(product.Name, Is.EqualTo(expectedProductData.Name), $"Product {nameof(product.Name)} does not match.");
                Assert.That(product.Price, Is.EqualTo(expectedProductData.Price), $"Product {nameof(product.Price)} does not match.");
                Assert.That(product.ImgUri, Is.EqualTo(expectedProductData.ImgUri), $"Product {nameof(product.ImgUri)} does not match.");
                Assert.That(product.Description, Is.EqualTo(expectedProductData.Description), $"Product {nameof(product.Description)} does not match.");
            });
        }

        private async Task<T> WithLogMessageHandling<T>(Func<Task<T>> function, Action<LogMessage> onMessageLogCallback)
        {
            try
            {
                this.Log += OnLog;
                return await function();
            }
            finally
            {
                this.Log -= OnLog;
            }

            void OnLog(object? sender, LogMessage message) => onMessageLogCallback(message);
        }

        private struct LogMessage(LogLevel logLevel, string message)
        {
            public LogLevel LogLevel { get; } = logLevel;

            public string Message { get; } = message;
        }
    }
}