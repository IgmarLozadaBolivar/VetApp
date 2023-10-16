namespace Domain.Entities;

public class ProveedorMedicamento
{
    public string IdMedicamentoFK { get; set; }
    public Medicamento Medicamento { get; set; }
    public string IdProveedorFK { get; set; }
    public Proveedor Proveedor { get; set; }
}