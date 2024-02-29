using System.Collections.Generic;
using VehiculoPrueba.Models;

namespace VehiculoPrueba.Services
{
    public interface ILocalidadService
    {
        List<Localidade> ObtenerTodasLasLocalidades();
        //Localidade ObtenerLocalidadPorId(int localidadId);

    }
}
