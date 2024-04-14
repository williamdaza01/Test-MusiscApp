using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Test_MusiscApp.Controllers;
using Test_MusiscApp.Data;
using Test_MusiscApp.Models;

namespace Test_MusiscApp.Tests.Controllers
{
    public class InventoryControllerTests
    {
        private InventoryController _inventoryController;
        private Mock<ApplicationDbContext> _mockDbContext;

        public InventoryControllerTests()
        {
            _mockDbContext = new Mock<ApplicationDbContext>();
            _inventoryController = new InventoryController(_mockDbContext.Object);
        }

        [Fact]
        public void Inventory_ReturnsViewWithAlbums()
        {
            // Arrange
            var albums = new List<Album> { new Album { /* Propiedades del álbum */ } };
            _mockDbContext.Setup(x => x.Album.ToList()).Returns(albums);

            // Act
            var result = _inventoryController.Inventory() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Album>>(result.ViewData.Model);
            Assert.Single(model);
        }

        [Fact]
        public void Create_RedirectToAlbumCreateAction()
        {
            // Act
            var result = _inventoryController.Create() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Create", result.ActionName);
            Assert.Equal("Album", result.ControllerName);
        }

        [Fact]
        public void CreateSong_RedirectToSongCreateAction()
        {
            // Arrange
            var albumId = 1;

            // Act
            var result = _inventoryController.CreateSong(albumId) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Create", result.ActionName);
            Assert.Equal("Song", result.ControllerName);
            Assert.Equal(albumId, result.RouteValues["albumId"]);
        }
    }
}
