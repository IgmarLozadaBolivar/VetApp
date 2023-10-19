namespace API.Dtos;

public class PropietarioxManyDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    //public UserDto users { get; set; }
    public List<MascotaDto> mascotas { get; set; }
    public List<MovimientoMedicamentoDto> movimientoMedicamentos { get; set; }
}