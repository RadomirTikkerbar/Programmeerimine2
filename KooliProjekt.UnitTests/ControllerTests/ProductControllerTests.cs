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
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _controller = new ProductController(null, _productServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_correct_view_with_data()
        {
            // Arrange
            int page = 1;
            var data = new List<Product>
            {
                new Product { Id = 1 },
                new Product { Id = 2 }
            };
            var pagedResult = new PagedResult<Product> { Results = data };
            _productServiceMock.Setup(x => x.List(page, It.IsAny<int>(), null)).ReturnsAsync(pagedResult);

            // Act
            var result = await _controller.Index(page) as ViewResult;

            // Assert
            Assert.NotNull(result);
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
                var product = (Product)null;
                _productServiceMock
                .Setup(x => x.Get(id.Value))
                    .ReturnsAsync(product);

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
                var product = new Product { Id = id.Value, Name = "Test 1" };
                _productServiceMock
                    .Setup(x => x.Get(id.Value))
                    .ReturnsAsync(product);

                // Act
                var result = await _controller.Details(id) as ViewResult;

                // Assert
                Assert.NotNull(result);
                Assert.True(
                    string.IsNullOrEmpty(result.ViewName) ||
                    result.ViewName == "Details"
                );
                Assert.Equal(product, result.Model);
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
                var product = (Product)null;
                _productServiceMock
                    .Setup(x => x.Get(id.Value))
                    .ReturnsAsync(product);

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
                var product = new Product { Id = id.Value, Name = "Test 1" };
                _productServiceMock
                    .Setup(x => x.Get(id.Value))
                    .ReturnsAsync(product);

                // Act
                var result = await _controller.Delete(id) as ViewResult;

                // Assert
                Assert.NotNull(result);
                Assert.True(
                    string.IsNullOrEmpty(result.ViewName) ||
                    result.ViewName == "Delete"
                );
                Assert.Equal(product, result.Model);
            }
        [Fact]
        public async Task DeleteConfirmed_should_delete_list()
        {
            // Arrange
            int id = 1;
            _productServiceMock
                .Setup(x => x.Delete(id))
        .Verifiable();

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            _productServiceMock.VerifyAll();
        }
    }
    }