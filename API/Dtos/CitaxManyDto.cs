using NodaTime;

namespace API.Dtos;

public class CitaxManyDto
{
    public int Id { get; set; }
    public MascotaDto mascotas { get; set; }
    public LocalDate Fecha { get; set; }
    public LocalTime Hora { get; set; }
    public string Motivo { get; set; }
    public VeterinarioDto veterinarios { get; set; }
}