using Domain.Entities;
namespace Domain.Interfaces;

public interface IMovimientoMedicamento : IGenericRepo<MovimientoMedicamento>
{
    // * Consultas
    Task<object> TotalCadaMovimiento();

    // * Metodos para Paginacion
    Task LoadTipoMovimientosAsync(MovimientoMedicamento movimientoMedicamento);
}