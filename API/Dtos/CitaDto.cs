using NodaTime;

namespace API.Dtos;

public class CitaDto
{
    public int Id { get; set; }
    public int IdMascotaFK { get; set; }
    //public MascotaDto Mascota { get; set; }
    public LocalDate Fecha { get; set; }
    public LocalTime Hora { get; set; }
    public string Motivo { get; set; }
    public int IdVeterinarioFK { get; set; }
    //public VeterinarioDto Veterinario { get; set; }
}