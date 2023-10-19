using Domain.Entities;
namespace API.Dtos;

public class DetalleMovimientoDto : BaseEntity
{
    public int IdMedicamentoFK { get; set; }
    public int Cantidad { get; set; }
    public int IdMovMedFK { get; set; }
    public decimal Precio { get; set; }
}