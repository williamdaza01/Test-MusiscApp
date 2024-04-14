using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Test_MusiscApp.Controllers;
using Test_MusiscApp.Data;
using Test_MusiscApp.Models;

namespace Test_MusiscApp.Tests.Controllers
{
    public class SongControllerTests
    {
        private SongController _songController;
        private Mock<ApplicationDbContext> _mockDbContext;

        public SongControllerTests()
        {
            _mockDbContext = new Mock<ApplicationDbContext>();
            _songController = new SongController(_mockDbContext.Object);
        }

        [Fact]
        public void Create_ReturnsView()
        {
            // Arrange
            var albumId = 1;

            // Act
            var result = _songController.Create(albumId) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Create_ValidModelState_RedirectsToAlbumDetails()
        {
            // Arrange
            var song = new Song { /* Propiedades de la canción */ };

            // Act
            var result = _songController.Create(song) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Details", result.ActionName);
            Assert.Equal("Album", result.ControllerName);
            Assert.NotNull(result.RouteValues["albumId"]);
        }

        [Fact]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var songId = 0;

            // Act
            var result = _songController.Delete(songId) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Details_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var albumId = 0;

            // Act
            var result = _songController.Details(albumId) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Edit_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var songId = 0;
            var song = new Song { /* Propiedades de la canción */ };

            // Act
            var result = _songController.Edit(songId, song) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        // Puedes agregar más pruebas aquí para otras acciones del controlador SongController según sea necesario

        [Fact]
        public void Edit_ValidModelState_RedirectsToAlbumDetails()
        {
            // Arrange
            var songId = 1;
            var song = new Song { /* Propiedades de la canción */ };

            // Act
            var result = _songController.Edit(songId, song) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Details", result.ActionName);
            Assert.Equal("Album", result.ControllerName);
            Assert.NotNull(result.RouteValues["albumId"]);
        }
    }
}
