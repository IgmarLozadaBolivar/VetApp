namespace API.Dtos;

public class CitaxManyDto
{
    public int Id { get; set; }
    public MascotaDto mascotas { get; set; }
    public DateOnly Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string Motivo { get; set; }
    public VeterinarioDto veterinarios { get; set; }
}