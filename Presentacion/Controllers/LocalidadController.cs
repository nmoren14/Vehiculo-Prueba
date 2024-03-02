using Microsoft.AspNetCore.Mvc;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Persistencia.Models;

namespace VehiculoPrueba.Presentacion.Controllers
{
    [ApiController]
    [Route("Localidad")]
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadService _localidadService;
        private readonly ILogger<LocalidadController> _logger;

        public LocalidadController(ILogger<LocalidadController> logger, ILocalidadService localidadService)
        {
            _logger = logger;
            _localidadService = localidadService;
        }


        [HttpGet("LocalDisponibles")]
        public ActionResult<List<Localidade>> ObtenerLocalidadesDisponibles()
        {
            try
            {
                var velocalidadesDisponibles = _localidadService.ObtenerTodasLasLocalidades();
                return Ok(velocalidadesDisponibles);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                return StatusCode(500, "Ocurrió un error interno al procesar la solicitud.");
            }
        }
    }
}