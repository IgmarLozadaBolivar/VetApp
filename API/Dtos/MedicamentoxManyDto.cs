namespace API.Dtos;

public class MedicamentoxManyDto
{
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    public LaboratorioDto laboratorios { get; set; }
}