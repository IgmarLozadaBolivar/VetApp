namespace Domain.Entities;

public class MovimientoMedicamento : BaseEntity
{
    public DateTime Fecha { get; set; }
    public string IdMedicamentoFK { get; set; }
    public Medicamento Medicamentos { get; set; }
    public string IdPropietarioFK { get; set; }
    public Propietario Propietarios { get; set; }
    public int Total { get; set; }
    public string IdTipoMovimientoFK { get; set; }
    public TipoMovimiento TipoMovimientos { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}