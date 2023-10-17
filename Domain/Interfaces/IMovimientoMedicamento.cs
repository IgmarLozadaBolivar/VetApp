using Domain.Entities;
namespace Domain.Interfaces;

public interface IMovimientoMedicamento : IGenericRepo<MovimientoMedicamento>
{
    // * Consultas
    Task<object> TotalCadaMovimiento();

    // * Metodos para Paginacion
    Task LoadMedicamentosAsync(MovimientoMedicamento movimientoMedicamento);
    Task LoadPropietariosAsync(MovimientoMedicamento movimientoMedicamento);
    Task LoadTipoMovimientosAsync(MovimientoMedicamento movimientoMedicamento);
}