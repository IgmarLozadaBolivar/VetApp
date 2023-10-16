namespace Domain.Entities;

public class MovimientoMedicamento : BaseEntity
{
    public DateTime Fecha { get; set; }
    public string IdMedicamentoFK { get; set; }
    public Medicamento Medicamento { get; set; }
    public string IdPropietarioFK { get; set; }
    public Propietario Propietario { get; set; }
    public int Total { get; set; }
    public string IdTipoMovimientoFK { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}