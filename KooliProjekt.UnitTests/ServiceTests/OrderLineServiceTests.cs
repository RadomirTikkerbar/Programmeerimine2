using KooliProjekt.Data;
using KooliProjekt.Services;
using Xunit;

namespace KooliProjekt.UnitTests.ServiceTests
{
    public class OrderLineServiceTests : ServiceTestBase
    {
        private readonly OrderLineService _service;

        public OrderLineServiceTests()
        {
            _service = new OrderLineService(DbContext);
        }

        [Fact]
        public async Task Delete_should_remove_existing_list()
        {
            // Arrange
            var list = new OrderLine { Amount = 3 };
            DbContext.OrderLine.Add(list);
            DbContext.SaveChanges();

            // Act
            await _service.Delete(list.Id);

            // Assert
            var count = DbContext.OrderLine.Count();
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
            var count = DbContext.OrderLine.Count();
            Assert.Equal(0, count);
        }
    }
}