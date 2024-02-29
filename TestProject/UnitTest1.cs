// Agregar estos usings al principio del archivo de pruebas
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using VehiculoPrueba;
using VehiculoPrueba.Models;
using Microsoft.EntityFrameworkCore;
using VehiculoPrueba.Services;

public class VehiculoServiceTests
{
    [Fact]
    public void ObtenerVehiculosDisponibles_DeberiaRetornarVehiculosCuandoHayDisponibles()
    {
        // Arrange
        var mockDbContext = new Mock<AppDbContext>();
        var mockLogger = new Mock<ILogger<VehiculoService>>();

        var vehiculosDisponibles = new List<Vehiculo>
        {
            new Vehiculo { Id = 1, Modelo = "Modelo1", LocalidadId = 1 },
            new Vehiculo { Id = 2, Modelo = "Modelo2", LocalidadId = 2 }
            // Agrega más vehículos según sea necesario
        };

        mockDbContext.Setup(db => db.Vehiculos).Returns(MockSet(vehiculosDisponibles));

        var vehiculoService = new VehiculoService(mockDbContext.Object, mockLogger.Object);

        // Act
        var resultado = vehiculoService.ObtenerVehiculosDisponibles(1);

        // Assert
        Assert.Equal(vehiculosDisponibles.Count, resultado.Count);
    }

    [Fact]
    public void ObtenerVehiculosDisponibles_DeberiaRetornarListaVaciaCuandoNoHayDisponibles()
    {
        // Arrange
        var mockDbContext = new Mock<AppDbContext>();
        var mockLogger = new Mock<ILogger<VehiculoService>>();

        var vehiculosDisponibles = new List<Vehiculo>(); // Sin vehículos disponibles

        mockDbContext.Setup(db => db.Vehiculos).Returns(MockSet(vehiculosDisponibles));

        var vehiculoService = new VehiculoService(mockDbContext.Object, mockLogger.Object);

        // Act
        var resultado = vehiculoService.ObtenerVehiculosDisponibles(1);

        // Assert
        Assert.Empty(resultado);
    }

    // Método auxiliar para simular DbSet en memoria usando Moq
    private static DbSet<T> MockSet<T>(List<T> elementos) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementos.AsQueryable().Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementos.AsQueryable().Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementos.AsQueryable().ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => elementos.GetEnumerator());
        return mockSet.Object;
    }
}
