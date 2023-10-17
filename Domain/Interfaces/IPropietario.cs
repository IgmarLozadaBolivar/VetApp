using Domain.Entities;
namespace Domain.Interfaces;

public interface IPropietario : IGenericRepo<Propietario>
{
    // * Consultas
    Task<object> MascotasConPropietarios();
    Task<object> MascotasGoldenRetriever();

    // * Paginacion
    //Task LoadUsersAsync(Propietario propietario); (Esto no es relevante)
    Task LoadMascotasAsync(string veterinarioId);
    Task LoadMovimientoMedicamentosAsync(string veterinarioId);
}