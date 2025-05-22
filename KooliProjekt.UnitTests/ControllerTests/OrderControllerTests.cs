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
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _controller = new OrderController(null, _orderServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_correct_view_with_data()
        {
            // Arrange
            int page = 1;
            var data = new List<Order>
            {
                new Order { Id = 1 },
                new Order { Id = 2 }
            };
            var pagedResult = new PagedResult<Order> { Results = data };
            _orderServiceMock.Setup(x => x.List(page, It.IsAny<int>(), null)).ReturnsAsync(pagedResult);

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
            var order = (Order)null;
            _orderServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(order);

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
            var order = new Order { Id = id.Value};
            _orderServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(order);

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Details"
            );
            Assert.Equal(order, result.Model);
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
            var order = (Order)null;
            _orderServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(order);

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
            var order = new Order { Id = id.Value };
            _orderServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(order);

            // Act
            var result = await _controller.Delete(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Delete"
            );
            Assert.Equal(order, result.Model);
        }
        #endregion

        [Fact]
        public async Task DeleteConfirmed_should_delete_list()
        {
            // Arrange
            int id = 1;
            _orderServiceMock
                .Setup(x => x.Delete(id))
                .Verifiable();

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            _orderServiceMock.VerifyAll();
        }
    }
}