using VehiculoPrueba.Models;

    public interface IVehiculoService
    {
        List<Vehiculo> ObtenerVehiculosDisponibles(int localidadRecogidaId);
        List<Localidade> ObtenerLocalidadesDisponibles();
    }