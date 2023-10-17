using Domain.Entities;
namespace Domain.Interfaces;

public interface ILaboratorio : IGenericRepo<Laboratorio>
{
    Task LoadMedicamentosAsync(string medicamentoId);
}