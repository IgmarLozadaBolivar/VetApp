namespace Domain.Entities;

public class Mascota : BaseEntity
{
    public string IdPropietarioFK { get; set; }
    public Propietario Propietario { get; set; }
    public string IdEspecieFK { get; set; }
    public Especie Especie { get; set; }
    public string IdRazaFK { get; set; }
    public Raza Raza { get; set; }
    public string Nombre { get; set; }
    public string FechaNac { get; set; }
    public ICollection<Cita> Citas { get; set; }
}