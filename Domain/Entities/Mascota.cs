namespace Domain.Entities;

public class Mascota : BaseEntity
{
    public string IdPropietarioFK { get; set; }
    public Propietario Propietarios { get; set; }
    public string IdEspecieFK { get; set; }
    public Especie Especies { get; set; }
    public string IdRazaFK { get; set; }
    public Raza Razas { get; set; }
    public string Nombre { get; set; }
    public string FechaNac { get; set; }
    public ICollection<Cita> Citas { get; set; }
}