using System;
using System.Collections.Generic;

namespace VehiculoPrueba.Core.Models;

public partial class Rentum
{
    public int Id { get; set; }

    public string? NombreUsuario { get; set; }

    public string? LocalidadDondeSeEncuentra { get; set; }

    public int? VehiculoId { get; set; }

    public int? LocalidadId { get; set; }

    public int? LocalidadRecogidaId { get; set; }

    public int? LocalidadDevolucionId { get; set; }

    public virtual Localidade? Localidad { get; set; }

    public virtual Localidade? LocalidadDevolucion { get; set; }

    public virtual Localidade? LocalidadRecogida { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
