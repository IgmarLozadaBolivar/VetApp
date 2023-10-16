namespace Domain.Entities;

public class DetalleMovimiento : BaseEntity
{
    public string IdMedicamentoFK { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public string IdMovMedFK { get; set; }
    public MovimientoMedicamento MovimientoMedicamento { get; set; }
    public decimal Precio { get; set; }
}