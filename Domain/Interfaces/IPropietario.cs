using Domain.Entities;
namespace Domain.Interfaces;

public interface IPropietario : IGenericRepo<Propietario>
{
    // * Consultas
    Task<object> MascotasConPropietarios();
    Task<object> MascotasGoldenRetriever();

    // * Paginacion
    Task LoadMascotasAsync(int veterinarioId);
    Task LoadMovimientoMedicamentosAsync(int veterinarioId);
    Task<(int totalRegistros, object registros)> MascotasGoldenRetriever(int pageIndez, int pageSize, string search);
}