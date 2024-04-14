using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Test_MusiscApp.Controllers;
using Test_MusiscApp.Data;
using Test_MusiscApp.Models;

namespace Test_MusiscApp.Tests.Controllers
{
    public class RegisterControllerTests
    {
        private RegisterController _registerController;
        private Mock<ApplicationDbContext> _mockDbContext;

        public RegisterControllerTests()
        {
            _mockDbContext = new Mock<ApplicationDbContext>();
            _registerController = new RegisterController(_mockDbContext.Object);
        }

        [Fact]
        public void Register_ValidClient_RedirectToSuccess()
        {
            // Arrange
            var client = new Cliente { /* Propiedades válidas del cliente */ };

            // Act
            var result = _registerController.Register(client) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("RegistroExitoso", result.ActionName);
        }

        [Fact]
        public void Register_InvalidClient_ReturnsViewWithError()
        {
            // Arrange
            var client = new Cliente { /* Propiedades inválidas del cliente */ };
            _registerController.ModelState.AddModelError("Name", "El nombre es requerido");

            // Act
            var result = _registerController.Register(client) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal(client, result.ViewData.Model);
        }
    }
}
