namespace API.Dtos;

public class MovimientoMedicamentoxManyDto
{
    public string Id { get; set; }
    public DateTime Fecha { get; set; }
    public MedicamentoDto medicamentos { get; set; }
    public PropietarioDto propietarios { get; set; }
    public int Total { get; set; }
    public TipoMovimientoDto tipoMovimientos { get; set; }
}