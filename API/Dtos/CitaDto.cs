namespace API.Dtos;

public class CitaDto
{
    public string Id { get; set; }
    public string IdMascotaFK { get; set; }
    //public MascotaDto Mascota { get; set; }
    public DateOnly Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string Motivo { get; set; }
    public string IdVeterinarioFK { get; set; }
    //public VeterinarioDto Veterinario { get; set; }
}