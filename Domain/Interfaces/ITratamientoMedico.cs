using Domain.Entities;
namespace Domain.Interfaces;

public interface ITratamientoMedico : IGenericRepo<TratamientoMedico>
{
    Task LoadCitasAsync(TratamientoMedico tratamientoMedico);
    Task LoadMedicamentosAsync(TratamientoMedico tratamientoMedico);
}