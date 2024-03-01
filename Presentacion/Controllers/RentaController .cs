using Microsoft.AspNetCore.Mvc;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Core.Models;

[ApiController]
[Route("Vehiculos")]
public class RentaController : ControllerBase
{
    private readonly IRentaService _rentaService;
    private readonly ILogger<RentaController> _logger;

    public RentaController(IRentaService rentaService, ILogger<RentaController> logger)
    {
        _rentaService = rentaService;
        _logger = logger;
    }

    [HttpPost("crear")]
    public IActionResult CrearNuevaRenta([FromBody] PRentum nuevaRenta)
    {
        try
        {
            _rentaService.CrearNuevaRenta(nuevaRenta);
            _logger.LogInformation("Renta creada exitosamente");
            return Ok("Renta creada exitosamente");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear la renta");
            return StatusCode(500, "Ocurrió un error interno al procesar la solicitud de Crear la Renta.");
        }
    }

}
