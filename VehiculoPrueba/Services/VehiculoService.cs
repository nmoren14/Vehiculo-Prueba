using VehiculoPrueba.Models;

namespace VehiculoPrueba
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
                // Consultar vehículos disponibles en la base de datos
                var vehiculosDisponibles = _dbContext.Vehiculos
                    .Where(v => v.LocalidadId == localidadRecogidaId)
                    .ToList();

                if (vehiculosDisponibles.Count == 0)
                {
                    _logger.LogInformation($"No se encontraron vehículos disponibles en la localidad de recogida {localidadRecogidaId}.");
                    return vehiculosDisponibles;
                }

                // Puedes realizar más lógica de filtrado según la localidad de devolución u otros criterios si es necesario

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
                // Consultar vehículos disponibles en la base de datos
                var localidadesDisponibles = _dbContext.Localidades.ToList();

                if (localidadesDisponibles.Count == 0)
                {
                    _logger.LogInformation($"No se encontraron Localidades.");
                    return localidadesDisponibles;
                }

                // Puedes realizar más lógica de filtrado según la localidad de devolución u otros criterios si es necesario

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