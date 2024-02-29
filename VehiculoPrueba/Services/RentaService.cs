// Agrega esto en tu archivo LocalidadService.cs dentro del directorio Services
using System.Collections.Generic;
using System.Linq;
using VehiculoPrueba.Models;

namespace VehiculoPrueba.Services
{
    public class RentaService : IRentaService
    {
        private readonly AppDbContext _dbContext;

        public RentaService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CrearNuevaRenta(PRentum nuevaRenta)
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
        }
    }
}
