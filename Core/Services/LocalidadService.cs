using Microsoft.Extensions.Logging;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Persistencia.Interfaces;
using VehiculoPrueba.Persistencia.Models;

namespace VehiculoPrueba.Core.Services
{
    public class LocalidadService : ILocalidadService
    {
        private readonly IAppDbContext _dbContext;
        private readonly ILogger<LocalidadService> _logger; 
        public LocalidadService(IAppDbContext dbContext, ILogger<LocalidadService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public List<Localidade> ObtenerTodasLasLocalidades()
        {
            try
            {
                var Localidades = _dbContext.Localidades.ToList();
                if (Localidades.Count == 0)
                {
                    _logger.LogInformation($"No se encontraron Localidades.");
                    return Localidades;
                }
                _logger.LogInformation($"Se han obtenido {Localidades.Count} localidades.");
                return Localidades;
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener las localidades.", ex);
            }
        }
    }
}
