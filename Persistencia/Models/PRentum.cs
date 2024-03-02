namespace VehiculoPrueba.Persistencia.Models;

public partial class PRentum
{
    public string NombreUsuario { get; set; }

    public string LocalidadDondeSeEncuentra { get; set; }

    public int? VehiculoId { get; set; }

    public int? LocalidadId { get; set; }

    public int? LocalidadRecogidaId { get; set; }

    public int? LocalidadDevolucionId { get; set; }

}
