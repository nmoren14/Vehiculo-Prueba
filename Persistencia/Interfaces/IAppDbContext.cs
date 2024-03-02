using Microsoft.EntityFrameworkCore;
using VehiculoPrueba.Persistencia.Models;


namespace VehiculoPrueba.Persistencia.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Localidade> Localidades { get; set; }
        DbSet<Rentum> Renta { get; set; }
        DbSet<Vehiculo> Vehiculos { get; set; }

        int SaveChanges();

    }
}
