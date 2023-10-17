using Domain.Entities;
namespace API.Dtos;

public class DetalleMovimientoDto : BaseEntity
{
    public string IdMedicamentoFK { get; set; }
    public int Cantidad { get; set; }
    public string IdMovMedFK { get; set; }
    public decimal Precio { get; set; }
}