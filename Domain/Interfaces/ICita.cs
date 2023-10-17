using Domain.Entities;
namespace Domain.Interfaces;

public interface ICita : IGenericRepo<Cita>
{
    Task LoadMascotasAsync(Cita cita);
    Task LoadVeterinariosAsync(Cita cita);
}