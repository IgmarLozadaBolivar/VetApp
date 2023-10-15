namespace Domain.Entities;

public class Propietario : BaseEntity
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public int IdUserFK { get; set; }
    public User User { get; set; }
    public ICollection<Mascota> Mascotas { get; set; }
    public ICollection<MovimientoMedicamento> MovimientoMedicamentos { get; set; }
}