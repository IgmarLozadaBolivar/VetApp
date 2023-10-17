using Domain.Entities;
namespace Domain.Interfaces;

public interface IDetalleMovimiento : IGenericRepo<DetalleMovimiento>
{
    Task LoadMedicamentosAsync(DetalleMovimiento detalleMovimiento);
    Task LoadMovimientoMedicamentosAsync(DetalleMovimiento detalleMovimiento);
}