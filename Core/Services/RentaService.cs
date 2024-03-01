using Microsoft.Extensions.Logging;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Core.Models;

namespace VehiculoPrueba.Core.Services
{
    public class RentaService : IRentaService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<RentaService> _logger; 

        public RentaService(AppDbContext dbContext, ILogger<RentaService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void CrearNuevaRenta(PRentum nuevaRenta)
        {

            try
            {
                Rentum renta = new Rentum();
                renta.NombreUsuario = nuevaRenta.NombreUsuario;
                renta.LocalidadDondeSeEncuentra = nuevaRenta.LocalidadDondeSeEncuentra;
                renta.VehiculoId = nuevaRenta.VehiculoId;
                renta.LocalidadId = nuevaRenta.LocalidadId;
                renta.LocalidadRecogidaId = nuevaRenta.LocalidadRecogidaId;
                renta.LocalidadDevolucionId = nuevaRenta.LocalidadDevolucionId;
                _dbContext.Renta.Add(renta);
                _dbContext.SaveChanges();

                _logger.LogInformation($"Nueva renta creada para el usuario {nuevaRenta.NombreUsuario}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el registro de Renta");
                throw new ApplicationException("Error al crear el registro de Renta.", ex);
            }

        }
    }
}
