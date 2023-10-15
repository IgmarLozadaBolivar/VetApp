namespace Domain.Entities;

public class MovimientoMedicamento : BaseEntity
{
    public DateTime Fecha { get; set; }
    public int IdMedicamentoFK { get; set; }
    public Medicamento Medicamento { get; set; }
    public int IdPropietarioFK { get; set; }
    public Propietario Propietario { get; set; }
    public int Total { get; set; }
    public int IdTipoMovimientoFK { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}