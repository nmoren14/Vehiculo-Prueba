// Agrega esto en tu archivo LocalidadService.cs dentro del directorio Services
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Core.Models;

namespace VehiculoPrueba.Core.Services
{
    public class LocalidadService : ILocalidadService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<LocalidadService> _logger; 
        public LocalidadService(AppDbContext dbContext, ILogger<LocalidadService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public List<Localidade> ObtenerTodasLasLocalidades()
        {
            try
            {
                var Localidades = _dbContext.Localidades.ToList();
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
