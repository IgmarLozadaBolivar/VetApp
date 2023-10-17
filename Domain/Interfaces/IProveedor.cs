using Domain.Entities;
namespace Domain.Interfaces;

public interface IProveedor : IGenericRepo<Proveedor>
{
    Task<object> MedicamentosPorProveedor();
}