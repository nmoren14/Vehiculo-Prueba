using VehiculoPrueba.Core.Models;

public interface IVehiculoService
    {
        List<Vehiculo> ObtenerVehiculosDisponibles(int localidadRecogidaId);
        List<Localidade> ObtenerLocalidadesDisponibles();
    }