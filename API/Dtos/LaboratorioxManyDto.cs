namespace API.Dtos;

public class LaboratorioxManyDto
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<MedicamentoDto> medicamentos { get; set; }
}