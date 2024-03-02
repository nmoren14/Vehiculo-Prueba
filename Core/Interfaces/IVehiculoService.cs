using VehiculoPrueba.Persistencia.Models;

public interface IVehiculoService
    {
        List<Vehiculo> ObtenerVehiculosDisponibles(int localidadRecogidaId);
    }