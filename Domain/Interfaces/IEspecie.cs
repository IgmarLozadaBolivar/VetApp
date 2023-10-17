using Domain.Entities;
namespace Domain.Interfaces;

public interface IEspecie : IGenericRepo<Especie>
{
    Task LoadRazasAsync(string razaId);
    Task LoadMascotasAsync(string mascotaId);
}