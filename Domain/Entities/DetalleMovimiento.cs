namespace Domain.Entities;

public class DetalleMovimiento : BaseEntity
{
    public int IdMedicamentoFK { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public int IdMovMedFK { get; set; }
    public MovimientoMedicamento MovimientoMedicamento { get; set; }
    public decimal Precio { get; set; }
}