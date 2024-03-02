using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VehiculoPrueba.Persistencia.Models;


namespace VehiculoPrueba.Core.Common
{
    public interface IAppDbContext
    {
        DbSet<Localidade> Localidades { get; set; }
        DbSet<Rentum> Renta { get; set; }
        DbSet<Vehiculo> Vehiculos { get; set; }

        int SaveChanges();

    }
}
