using Domain.Entities;
namespace Domain.Interfaces;

public interface IMascota : IGenericRepo<Mascota>
{
    // * Consultas
    Task<object> MascotasEspeciesFelinas();
    Task<IEnumerable<Mascota>> MascotasVacunacionPrimerTrimestre2023();
    Task<object> EspeciesMascotas();
    Task<object> MascotaAtendidaPorVeterinario();
    Task<object> RazasCantidadMascotas();

    // * Metodos para Paginacion
    Task LoadPropietariosAsync(Mascota mascota);
    Task LoadRazasAsync(Mascota mascota);
}