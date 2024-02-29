using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehiculoPrueba.Models;
using VehiculoPrueba.Services;

[ApiController]
[Route("Vehiculos")]
public class RentaController : ControllerBase
{
    private readonly IRentaService _rentaService;

    public RentaController(IRentaService rentaService)
    {
        _rentaService = rentaService;
    }

    [HttpPost("crear")]
    public IActionResult CrearNuevaRenta([FromBody] PRentum nuevaRenta)
    {
        _rentaService.CrearNuevaRenta(nuevaRenta);
        return Ok("Renta creada exitosamente");
    }

    // Otros métodos del controlador...
}
