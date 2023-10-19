using Domain.Entities;
namespace Domain.Interfaces;

public interface IRaza : IGenericRepo<Raza>
{
    Task LoadEspeciesAsync(Raza raza);
    Task LoadMascotasAsync(int razaId);
}