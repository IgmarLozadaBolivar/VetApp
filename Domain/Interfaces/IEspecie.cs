using Domain.Entities;
namespace Domain.Interfaces;

public interface IEspecie : IGenericRepo<Especie>
{
    Task LoadRazasAsync(int razaId);
    Task LoadMascotasAsync(int mascotaId);
}