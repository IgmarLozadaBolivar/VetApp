using Domain.Entities;
using NodaTime;
namespace API.Dtos;

public class MovimientoMedicamentoDto : BaseEntity
{
    public LocalDateTime Fecha { get; set; }
    public int IdMedicamentoFK { get; set; }
    public int IdPropietarioFK { get; set; }
    public int Total { get; set; }
    public int IdTipoMovimientoFK { get; set; }
}