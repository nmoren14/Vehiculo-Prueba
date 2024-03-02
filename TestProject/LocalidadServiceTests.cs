using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using VehiculoPrueba.Core.Services;
using VehiculoPrueba.Persistencia.Interfaces;
using VehiculoPrueba.Persistencia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Presentacion.Controllers;

namespace TestProject
{
    public class LocalidadServiceTests
    {
        [Fact]
        public void ObtenerTodasLasLocalidades_DeberiaRetornarOk()
        {
            // Arrange
            var mockDbContext = new Mock<IAppDbContext>();
            var mockLogger = new Mock<ILogger<LocalidadService>>();

            var localidadService = new LocalidadService(mockDbContext.Object, mockLogger.Object);

            // Act
            var result = localidadService.ObtenerTodasLasLocalidades();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Localidade>>(result);
        }
    }

    public class LocalidadControllerTests
    {
        [Fact]
        public void ObtenerLocalidadesDisponibles_DeberiaRetornarOk()
        {
            // Arrange
            var mockLocalidadService = new Mock<ILocalidadService>();
            var mockLogger = new Mock<ILogger<LocalidadController>>();

            mockLocalidadService.Setup(service => service.ObtenerTodasLasLocalidades())
                .Returns(new List<Localidade>()); // Puedes ajustar esto con datos de prueba

            var localidadController = new LocalidadController(mockLogger.Object, mockLocalidadService.Object);

            // Act
            var result = localidadController.ObtenerLocalidadesDisponibles();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<List<Localidade>>(okObjectResult.Value);

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
            Assert.NotNull(value);
            Assert.IsType<List<Localidade>>(value);
        }
    }
}
