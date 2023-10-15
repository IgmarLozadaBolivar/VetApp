namespace Domain.Entities;

public class Medicamento : BaseEntity
{
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    public int IdLaboratorioFK { get; set; }
    public Laboratorio Laboratorio { get; set; }
    public ICollection<Proveedor> Proveedores { get; set; }
    public ICollection<MovimientoMedicamento> MovimientoMedicamentos { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    public ICollection<ProveedorMedicamento> ProveedorMedicamentos { get; set; }
    public ICollection<TratamientoMedico> TratamientoMedicos { get; set; }
}