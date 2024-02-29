using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehiculoPrueba.Models;
using VehiculoPrueba.Services;

[ApiController]
[Route("Vehiculos")]
public class VehiculoController : ControllerBase
{
    private readonly IVehiculoService _vehiculoService;
    private readonly ILogger<VehiculoController> _logger;
    private readonly ILocalidadService _localidadService;

    public VehiculoController(IVehiculoService vehiculoService, ILogger<VehiculoController> logger, ILocalidadService localidadService)
    {
        _vehiculoService = vehiculoService;
        _logger = logger;
        _localidadService = localidadService;
    }

    [HttpGet("VehDdisponibles")]
    public ActionResult<List<Vehiculo>> ObtenerVehiculosDisponibles(int localidadRecogidaId)
    {
        try
        {
            var vehiculosDisponibles = _vehiculoService.ObtenerVehiculosDisponibles(localidadRecogidaId);
            return Ok(vehiculosDisponibles);
        }
        catch (Exception ex)
        {
            // Manejar la excepción
            return StatusCode(500, "Ocurrió un error interno al procesar la solicitud.");
        }
    }

    [HttpGet("LocalDisponibles")]
    public ActionResult<List<Localidade>> ObtenerLocalidadesDisponibles()
    {
        try
        {
            var velocalidadesDisponibles = _vehiculoService.ObtenerLocalidadesDisponibles();
            return Ok(velocalidadesDisponibles);
        }
        catch (Exception ex)
        {
            // Manejar la excepción
            return StatusCode(500, "Ocurrió un error interno al procesar la solicitud.");
        }
    }
}
