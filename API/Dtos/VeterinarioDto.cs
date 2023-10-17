namespace API.Dtos;

public class VeterinarioDto
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Especialidad { get; set; }
    public string IdUserFK { get; set; }
}