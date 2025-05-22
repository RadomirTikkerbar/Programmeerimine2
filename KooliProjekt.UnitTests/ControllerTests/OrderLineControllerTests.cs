using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KooliProjekt.Controllers;
using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class OrderLineControllerTests
    {
        private readonly Mock<IOrderLineService> _orderLineServiceMock;
        private readonly OrderLineController _controller;

        public OrderLineControllerTests()
        {
            _orderLineServiceMock = new Mock<IOrderLineService>();
            _controller = new OrderLineController(null, _orderLineServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_correct_view_with_data()
        {
            // Arrange
            int page = 1;
            var data = new List<OrderLine>
            {
                new OrderLine { Id = 1 },
                new OrderLine { Id = 2 }
            };
            var pagedResult = new PagedResult<OrderLine> { Results = data };
            _orderLineServiceMock.Setup(x => x.List(page, It.IsAny<int>(), null)).ReturnsAsync(pagedResult);

            // Act
            var result = await _controller.Index(page) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pagedResult, result.Model);
        }


        [Fact]
        public async Task Details_should_return_notfound_when_id_is_null()
        {
            // Arrange
            int? id = null;

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_item_was_not_found()
        {
            // Arrange
            int? id = 1;
            var orderLine = (OrderLine)null;
            _orderLineServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(orderLine);

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Details_should_return_correct_view_with_model_when_item_was_found()
        {
            // Arrange
            int? id = 1;
            var orderLine = new OrderLine { Id = id.Value};
            _orderLineServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(orderLine);

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Details"
            );
            Assert.Equal(orderLine, result.Model);
        }

        [Fact]
        public void Create_should_return_correct_view()
        {
            // Arrange

            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Create"
            );
        }

        #region Delete tests
        [Fact]
        public async Task Delete_should_return_notfound_when_id_is_null()
        {
            // Arrange
            int? id = null;

            // Act
            var result = await _controller.Delete(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_should_return_notfound_when_item_was_not_found()
        {
            // Arrange
            int? id = 1;
            var todoList = (OrderLine)null;
            _orderLineServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(todoList);

            // Act
            var result = await _controller.Delete(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_should_return_correct_view_with_model_when_item_was_found()
        {
            // Arrange
            int? id = 1;
            var orderLine = new OrderLine { Id = id.Value};
            _orderLineServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(orderLine);

            // Act
            var result = await _controller.Delete(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Delete"
            );
            Assert.Equal(orderLine, result.Model);
        }
        #endregion
        [Fact]
        public async Task DeleteConfirmed_should_delete_list()
        {
            // Arrange
            int id = 1;
            _orderLineServiceMock
                .Setup(x => x.Delete(id))
        .Verifiable();

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            _orderLineServiceMock.VerifyAll();
        }
    }
}