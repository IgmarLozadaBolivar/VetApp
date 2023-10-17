namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IVeterinario Veterinarios { get; }
    IMedicamento Medicamentos { get; }
    IMascota Mascotas { get; }
    IPropietario Propietarios { get; }
    IMovimientoMedicamento MovimientoMedicamentos { get; }
    IProveedor Proveedores { get; }
    ICita Citas { get; }
    IDetalleMovimiento DetalleMovimientos { get; }
    IEspecie Especies { get; }
    ILaboratorio Laboratorios { get; }
    IRaza Razas { get; }
    ITipoMovimiento TipoMovimientos { get; }
    ITratamientoMedico TratamientoMedicos { get; }
    IUser Users { get; }
    Task<int> SaveAsync();
}