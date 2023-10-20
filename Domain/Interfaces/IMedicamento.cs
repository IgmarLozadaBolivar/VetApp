using Domain.Entities;
namespace Domain.Interfaces;

public interface IMedicamento : IGenericRepo<Medicamento>
{
    // * Consultas
    Task<IEnumerable<Medicamento>> MedicamentosLaboratoriosGenfar();
    Task<IEnumerable<Medicamento>> PrecioMayorA50k();

    // * Metodo para paginacion
    Task LoadLaboratoriosAsync(Medicamento medicamento);

    Task<(int totalRegistros, object registros)> MedicamentosLaboratoriosGenfar(int pageIndez, int pageSize, string search);
}