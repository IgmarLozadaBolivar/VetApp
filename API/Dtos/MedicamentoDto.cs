using Domain.Entities;
namespace API.Dtos;

public class MedicamentoDto : BaseEntity
{
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    public int IdLaboratorioFK { get; set; }
}