using System.Collections.Generic;
using VehiculoPrueba.Core.Models;

namespace VehiculoPrueba.Core.Interfaces
{
    public interface ILocalidadService
    {
        List<Localidade> ObtenerTodasLasLocalidades();
        //Localidade ObtenerLocalidadPorId(int localidadId);

    }
}
