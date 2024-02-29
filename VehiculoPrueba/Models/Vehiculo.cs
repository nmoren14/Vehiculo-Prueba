using System;
using System.Collections.Generic;

namespace VehiculoPrueba.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public int AñoFabricacion { get; set; }

    public int? LocalidadId { get; set; }

    public virtual Localidade? Localidad { get; set; }

    public virtual ICollection<Rentum> Renta { get; set; } = new List<Rentum>();
}
