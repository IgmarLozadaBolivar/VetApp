using Domain.Entities;
namespace API.Dtos;

public class MovimientoMedicamentoDto : BaseEntity
{
    public DateTime Fecha { get; set; }
    public string IdMedicamentoFK { get; set; }
    public string IdPropietarioFK { get; set; }
    public int Total { get; set; }
    public string IdTipoMovimientoFK { get; set; }
}