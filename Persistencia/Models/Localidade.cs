using System;
using System.Collections.Generic;

namespace VehiculoPrueba.Core.Models;

public partial class Localidade
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Rentum> RentumLocalidadDevolucions { get; set; } = new List<Rentum>();

    public virtual ICollection<Rentum> RentumLocalidadRecogida { get; set; } = new List<Rentum>();

    public virtual ICollection<Rentum> RentumLocalidads { get; set; } = new List<Rentum>();

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
