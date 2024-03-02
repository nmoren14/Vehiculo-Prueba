using Microsoft.Extensions.Logging;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Persistencia;

namespace VehiculoPrueba.Core.Services
{
    public class TestService : ITestService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<TestService> _logger; 

        public TestService(AppDbContext dbContext, ILogger<TestService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public string TestDatabaseConnection()
        {
            try
            {
                // Realizar una consulta simple para probar la conexión
                var vehiculoCount = _dbContext.Vehiculos.Count();
                var localidadCount = _dbContext.Localidades.Count();
                var rentaCount = _dbContext.Renta.Count();

                _logger.LogInformation($"Conexión a la base de datos probada exitosamente.");

                return $"La conexión a la base de datos funciona. Número de vehículos: {vehiculoCount} // " +
                       $"Número de localidades: {localidadCount} // Número de Rentas: {rentaCount}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al probar la conexión a la base de datos.");
                throw new ApplicationException("Error al probar la conexión a la base de datos.", ex);
            }
        }
    }
}
