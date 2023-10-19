namespace API.Dtos;

public class VeterinarioxManyDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Especialidad { get; set; }
    public List<CitaDto> citas { get; set; }
}