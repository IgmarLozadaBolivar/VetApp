namespace API.Dtos;

public class RazaxManyDto
{
    public int Id { get; set; }
    public EspecieDto especies { get; set; }
    public string Nombre { get; set; }
    public List<MascotaDto> mascotas { get; set; }
}