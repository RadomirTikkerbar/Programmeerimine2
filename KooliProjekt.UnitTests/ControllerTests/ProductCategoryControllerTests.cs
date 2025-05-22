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
    public class ProductCategoryControllerTests
    {
        private readonly Mock<IProductCategoryService> _productCategoryServiceMock;
        private readonly ProductCategoryController _controller;

        public ProductCategoryControllerTests()
        {
            _productCategoryServiceMock = new Mock<IProductCategoryService>();
            _controller = new ProductCategoryController(null, _productCategoryServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_correct_view_with_data()
        {
            // Arrange
            int page = 1;
            var data = new List<ProductCategory>
            {
                new ProductCategory { Id = 1 },
                new ProductCategory { Id = 2 }
            };
            var pagedResult = new PagedResult<ProductCategory> { Results = data };
            _productCategoryServiceMock.Setup(x => x.List(page, It.IsAny<int>(), null)).ReturnsAsync(pagedResult);

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
                var productCategory = (ProductCategory)null;
                _productCategoryServiceMock
                .Setup(x => x.Get(id.Value))
                    .ReturnsAsync(productCategory);

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
                var productCategory = new ProductCategory { Id = id.Value, Name = "Test 1" };
                _productCategoryServiceMock
                    .Setup(x => x.Get(id.Value))
                    .ReturnsAsync(productCategory);

                // Act
                var result = await _controller.Details(id) as ViewResult;

                // Assert
                Assert.NotNull(result);
                Assert.True(
                    string.IsNullOrEmpty(result.ViewName) ||
                    result.ViewName == "Details"
                );
                Assert.Equal(productCategory, result.Model);
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
                var todoList = (ProductCategory)null;
                _productCategoryServiceMock
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
                var productCategory = new ProductCategory { Id = id.Value, Name = "Test 1" };
                _productCategoryServiceMock
                    .Setup(x => x.Get(id.Value))
                    .ReturnsAsync(productCategory);

                // Act
                var result = await _controller.Delete(id) as ViewResult;

                // Assert
                Assert.NotNull(result);
                Assert.True(
                    string.IsNullOrEmpty(result.ViewName) ||
                    result.ViewName == "Delete"
                );
                Assert.Equal(productCategory, result.Model);
            }
        [Fact]
        public async Task DeleteConfirmed_should_delete_list()
        {
            // Arrange
            int id = 1;
            _productCategoryServiceMock
                .Setup(x => x.Delete(id))
        .Verifiable();

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            _productCategoryServiceMock.VerifyAll();
        }
    }
    }