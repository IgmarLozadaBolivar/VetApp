namespace Domain.Entities;

public class Proveedor : BaseEntity
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string IdUserFK { get; set; }
    public User User { get; set; }
    public ICollection<Medicamento> Medicamentos { get; set; }
    public ICollection<ProveedorMedicamento> ProveedorMedicamentos { get; set; }
}