using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VehiculoPrueba.Models;

namespace VehiculoPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public TestController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<string> TestDatabaseConnection()
        {
            // Realizar una consulta simple para probar la conexión
            var vehiculoCount = _dbContext.Vehiculos.Count();

            return Ok($"La conexión a la base de datos funciona. Número de vehículos: {vehiculoCount}");
        }
    }
}
