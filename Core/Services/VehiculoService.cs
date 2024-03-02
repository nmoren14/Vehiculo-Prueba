using Microsoft.Extensions.Logging;
using VehiculoPrueba.Persistencia.Interfaces;
using VehiculoPrueba.Persistencia.Models;

namespace VehiculoPrueba.Core.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IAppDbContext _dbContext;
        private readonly ILogger<VehiculoService> _logger;

        public VehiculoService(IAppDbContext dbContext, ILogger<VehiculoService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public List<Vehiculo> ObtenerVehiculosDisponibles(int localidadRecogidaId)
        {
            try
            {
                    var vehiculosDisponibles = _dbContext.Vehiculos
                    .Where(v => v.LocalidadId == localidadRecogidaId)
                    .ToList();

                if (vehiculosDisponibles.Count == 0)
                {
                    _logger.LogInformation($"No se encontraron vehículos disponibles en la localidad de recogida {localidadRecogidaId}.");
                    return vehiculosDisponibles;
                }                

                _logger.LogInformation($"Se encontraron {vehiculosDisponibles.Count} vehículos disponibles en la localidad de recogida {localidadRecogidaId}.");
                return vehiculosDisponibles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener vehículos disponibles.");
                throw;
            }
        }
                
    }
}