using Domain.Entities;
namespace API.Dtos;

public class TratamientoMedicoDto : BaseEntity
{
    public int IdCitaFK { get; set; }
    public int IdMedicamentoFK { get; set; }
    public string Dosis { get; set; }
    public string DetalleConsumo { get; set; }
    public string Observacion { get; set; }
}