using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Test_MusiscApp.Controllers;
using Test_MusiscApp.Data;
using Test_MusiscApp.Models;

namespace Test_MusiscApp.Tests.Controllers
{
    public class AlbumControllerTests
    {
        private AlbumController _albumController;
        private Mock<ApplicationDbContext> _mockDbContext;

        public AlbumControllerTests()
        {
            _mockDbContext = new Mock<ApplicationDbContext>();
            _albumController = new AlbumController(_mockDbContext.Object);
        }

        [Fact]
        public void Create_ReturnsView()
        {
            // Act
            var result = _albumController.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Create_ValidModelState_RedirectsToCreationSuccess()
        {
            // Arrange
            var album = new Album { /* Propiedades del álbum */ };

            // Act
            var result = _albumController.Create(album) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("CreationSuccess", result.ActionName);
            Assert.Equal("Album", result.ControllerName);
        }

        [Fact]
        public void Details_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var albumId = 0;

            // Act
            var result = _albumController.Details(albumId) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var albumId = 0;

            // Act
            var result = _albumController.Delete(albumId) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Edit_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var albumId = 0;
            var album = new Album { /* Propiedades del álbum */ };

            // Act
            var result = _albumController.Edit(albumId, album) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Edit_ValidModelState_RedirectsToDetails()
        {
            // Arrange
            var albumId = 1;
            var album = new Album { /* Propiedades del álbum */ };

            // Act
            var result = _albumController.Edit(albumId, album) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Details", result.ActionName);
            Assert.Equal("Album", result.ControllerName);
            Assert.Equal(albumId, result.RouteValues["albumId"]);
        }
    }
}
