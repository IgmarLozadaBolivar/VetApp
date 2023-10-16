namespace Domain.Entities;

public class Cita : BaseEntity
{
    public string IdMascotaFK { get; set; }
    public Mascota Mascota { get; set; }
    public DateOnly Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string Motivo { get; set; }
    public string IdVeterinarioFK { get; set; }
    public Veterinario Veterinario { get; set; }
    public ICollection<TratamientoMedico> TratamientoMedicos { get; set; }
}