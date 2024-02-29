using Microsoft.EntityFrameworkCore;
using VehiculoPrueba.Models;

namespace VehiculoPrueba;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Localidade> Localidades { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Rentum> Renta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MilesCarRentalDB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Localidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Localida__3214EC076007802B");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Rentum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Renta__3214EC07F132BB92");

            entity.Property(e => e.LocalidadDondeSeEncuentra).HasMaxLength(255);
            entity.Property(e => e.NombreUsuario).HasMaxLength(255);

            entity.HasOne(d => d.LocalidadDevolucion).WithMany(p => p.RentumLocalidadDevolucions)
                .HasForeignKey(d => d.LocalidadDevolucionId)
                .HasConstraintName("FK_Renta_LocalidadDevolucion");

            entity.HasOne(d => d.Localidad).WithMany(p => p.RentumLocalidads)
                .HasForeignKey(d => d.LocalidadId)
                .HasConstraintName("FK_Renta_Localidad");

            entity.HasOne(d => d.LocalidadRecogida).WithMany(p => p.RentumLocalidadRecogida)
                .HasForeignKey(d => d.LocalidadRecogidaId)
                .HasConstraintName("FK_Renta_LocalidadRecogida");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Renta)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK_Renta_Vehiculos");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3214EC07CBEB6ACD");

            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.Modelo).HasMaxLength(100);

            entity.HasOne(d => d.Localidad).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.LocalidadId)
                .HasConstraintName("FK__Vehiculos__Local__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
