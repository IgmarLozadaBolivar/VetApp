using NodaTime;

namespace Domain.Entities;

public class MovimientoMedicamento : BaseEntity
{
    public LocalDateTime Fecha { get; set; }
    public int Total { get; set; }
    public int IdTipoMovimientoFK { get; set; }
    public TipoMovimiento TipoMovimientos { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}