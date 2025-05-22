using KooliProjekt.Data;
using KooliProjekt.Services;
using Xunit;

namespace KooliProjekt.UnitTests.ServiceTests
{
    public class ProductCategoryServiceTests : ServiceTestBase
    {
        private readonly ProductCategoryService _service;

        public ProductCategoryServiceTests()
        {
            _service = new ProductCategoryService(DbContext);
        }

        [Fact]
        public async Task Delete_should_remove_existing_list()
        {
            // Arrange
            var list = new ProductCategory { Name = "Test" };
            DbContext.ProductCategory.Add(list);
            DbContext.SaveChanges();

            // Act
            await _service.Delete(list.Id);

            // Assert
            var count = DbContext.ProductCategory.Count();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Delete_should_return_if_list_was_not_found()
        {
            // Arrange
            var id = -100;

            // Act
            await _service.Delete(id);

            // Assert
            var count = DbContext.ProductCategory.Count();
            Assert.Equal(0, count);
        }
    }
}