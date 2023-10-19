using NodaTime;

namespace Domain.Entities;

public class Cita : BaseEntity
{
    public int IdMascotaFK { get; set; }
    public Mascota Mascotas { get; set; }
    public LocalDate Fecha { get; set; }
    public LocalTime Hora { get; set; }
    public string Motivo { get; set; }
    public int IdVeterinarioFK { get; set; }
    public Veterinario Veterinarios { get; set; }
    public ICollection<TratamientoMedico> TratamientoMedicos { get; set; }
}