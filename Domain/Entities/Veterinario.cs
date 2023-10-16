namespace Domain.Entities;

public class Veterinario : BaseEntity
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Especialidad { get; set; }
    public string IdUserFK { get; set; }
    public User User { get; set; }
    public ICollection<Cita> Citas { get; set; }
}