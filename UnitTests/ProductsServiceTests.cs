using Application.Mappings;
using Application.Services;
using AutoMapper;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests
{
    public class ProductsServiceTests
    {
        private Mock<ILogger<ProductsService>> mockLogger;
        private ProductsService service;

        [SetUp]
        public void Setup()
        {
            MockProductsRepository repository = new MockProductsRepository();

            this.mockLogger = new Mock<ILogger<ProductsService>>();

            IMapper mockMapper = new MapperConfiguration(ConfigureMapper).CreateMapper();
            void ConfigureMapper(IMapperConfigurationExpression expression) => expression.AddProfile(new MappingProfile());

            this.service = new ProductsService(repository, mockMapper, this.mockLogger.Object);
        }
    }

    // TODO: Add tests
}