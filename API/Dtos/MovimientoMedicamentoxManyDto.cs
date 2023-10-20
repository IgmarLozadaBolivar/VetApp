using NodaTime;

namespace API.Dtos;

public class MovimientoMedicamentoxManyDto
{
    public int Id { get; set; }
    public LocalDateTime Fecha { get; set; }
    public MedicamentoDto medicamentos { get; set; }
    public PropietarioDto propietarios { get; set; }
    public int Total { get; set; }
    public TipoMovimientoDto tipoMovimientos { get; set; }
}