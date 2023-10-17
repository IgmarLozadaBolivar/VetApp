using Domain.Entities;
namespace Domain.Interfaces;

public interface IMedicamento : IGenericRepo<Medicamento>
{
    // * Consultas
    Task<IEnumerable<Medicamento>> MedicamentosLaboratoriosGenfar();
    Task<IEnumerable<Medicamento>> PrecioMayorA50k();

    // * Metodo para paginacion
    Task LoadLaboratoriosAsync(Medicamento medicamento);
}