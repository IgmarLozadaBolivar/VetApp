namespace Domain.Entities;

public class Mascota : BaseEntity
{
    public int IdPropietarioFK { get; set; }
    public Propietario Propietario { get; set; }
    public int IdEspecieFK { get; set; }
    public Especie Especie { get; set; }
    public int IdRazaFK { get; set; }
    public Raza Raza { get; set; }
    public string Nombre { get; set; }
    public string FechaNac { get; set; }
    public ICollection<Cita> Citas { get; set; }
}