namespace Domain.Entities;

public class Raza : BaseEntity
{
    public string IdEspecieFK { get; set; }
    public Especie Especies { get; set; }
    public string Nombre { get; set; }
    public ICollection<Mascota> Mascotas { get; set; }
}