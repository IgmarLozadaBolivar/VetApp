using Domain.Entities;
namespace Domain.Interfaces;

public interface IVeterinario : IGenericRepo<Veterinario>
{
    // * Consultas
    Task<IEnumerable<Veterinario>> VeterinariosCirujanosVasculares();

    // * Paginacion
    Task LoadCitasAsync(string veterinarioId);
}