using Microsoft.Extensions.Logging;
using Moq;
using VehiculoPrueba.Core.Services;
using VehiculoPrueba.Persistencia.Interfaces;
using VehiculoPrueba.Persistencia.Models;

    namespace TestProject
{
    public class VehiculoServiceTests
    {
        [Fact]
        public void ObtenerVehiculosDisponibles_DeberiaRetornarListaVehiculos()
        {
            // Arrange
            var dbContextMock = new Mock<IAppDbContext>();
            var loggerMock = new Mock<ILogger<VehiculoService>>();

            var vehiculoService = new VehiculoService(dbContextMock.Object, loggerMock.Object);

            // Act
            var result = vehiculoService.ObtenerVehiculosDisponibles(1); // Pasa el ID de la localidad

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Vehiculo>>(result);
            // Puedes realizar más aserciones según tus necesidades
        }       
    }
}
