using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using VehiculoPrueba.Core.Services;
using VehiculoPrueba.Persistencia.Interfaces;
using VehiculoPrueba.Persistencia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Presentacion.Controllers;

namespace TestProject
{
    public class RentaServiceTests
    {
        [Fact]
        public void CrearNuevaRenta_DeberiaRetornarOk()
        {
            // Arrange
            var mockDbContext = new Mock<IAppDbContext>();
            var mockLogger = new Mock<ILogger<RentaService>>();

            var rentaService = new RentaService(mockDbContext.Object, mockLogger.Object);

            // Act
            var nuevaRenta = new PRentum
            {
                NombreUsuario = "UsuarioPrueba",
                LocalidadDondeSeEncuentra = "LocalidadPrueba",
                VehiculoId = 1,
                LocalidadId = 2,
                LocalidadRecogidaId = 3,
                LocalidadDevolucionId = 4
            };

            var result = Record.Exception(() => rentaService.CrearNuevaRenta(nuevaRenta));

            // Assert
            Assert.Null(result); // Asegura que no haya excepciones
        }
    }
}
