using NodaTime;

namespace Domain.Entities;

public class Mascota : BaseEntity
{
    public int IdPropietarioFK { get; set; }
    public Propietario Propietarios { get; set; }
    public int IdRazaFK { get; set; }
    public Raza Razas { get; set; }
    public string Nombre { get; set; }
    public LocalDate FechaNac { get; set; }
    public ICollection<Cita> Citas { get; set; }
}