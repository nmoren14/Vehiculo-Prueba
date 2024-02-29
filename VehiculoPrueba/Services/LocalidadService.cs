// Agrega esto en tu archivo LocalidadService.cs dentro del directorio Services
using System.Collections.Generic;
using System.Linq;
using VehiculoPrueba.Models;

namespace VehiculoPrueba.Services
{
    public class LocalidadService : ILocalidadService
    {
        private readonly AppDbContext _dbContext;

        public LocalidadService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Localidade> ObtenerTodasLasLocalidades()
        {
            return _dbContext.Localidades.ToList();
        }
    }
}
