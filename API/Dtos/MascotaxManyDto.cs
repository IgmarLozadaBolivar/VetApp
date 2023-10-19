namespace API.Dtos;

public class MascotaxManyDto
{
    public int Id { get; set; }
    public PropietarioDto propietarios { get; set; }
    public EspecieDto especies { get; set; }
    public RazaDto razas { get; set; }
    public string Nombre { get; set; }
    public string FechaNac { get; set; }
}