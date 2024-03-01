using Microsoft.Extensions.Logging;
using VehiculoPrueba.Core.Models;

namespace VehiculoPrueba.Core.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<VehiculoService> _logger;

        public VehiculoService(AppDbContext dbContext, ILogger<VehiculoService> logger)
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

        public List<Localidade> ObtenerLocalidadesDisponibles()
        {
            try
            {
                var localidadesDisponibles = _dbContext.Localidades.ToList();

                if (localidadesDisponibles.Count == 0)
                {
                    _logger.LogInformation($"No se encontraron Localidades.");
                    return localidadesDisponibles;
                }
                
                _logger.LogInformation($"Se encontraron {localidadesDisponibles.Count} Localidades.");
                return localidadesDisponibles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener Localidades disponibles.");
                throw;
            }
        }
    }
}