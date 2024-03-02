using Microsoft.AspNetCore.Mvc;
using VehiculoPrueba.Core.Interfaces;

namespace VehiculoPrueba.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ILogger<TestController> _logger;

        public TestController(ITestService testService, ILogger<TestController> logger)
        {
            _testService = testService;
            _logger = logger;
        }

        [HttpGet]
        [HttpGet]
        public IActionResult TestDatabaseConnection()
        {
            try
            {
                var result = _testService.TestDatabaseConnection();
                _logger.LogInformation("Conexión a la base de datos probada exitosamente");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al probar la conexión a la base de datos");
                return StatusCode(500, "Ocurrió un error interno al procesar la solicitud.");
            }
        }
    }
}
