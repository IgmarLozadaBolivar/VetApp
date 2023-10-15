namespace Domain.Entities;

public class ProveedorMedicamento
{
    public int IdMedicamentoFK { get; set; }
    public Medicamento Medicamento { get; set; }
    public int IdProveedorFK { get; set; }
    public Proveedor Proveedor { get; set; }
}