using Domain.Entities;
namespace API.Dtos;

public class TratamientoMedicoDto : BaseEntity
{
    public string IdCitaFK { get; set; }
    public string IdMedicamentoFK { get; set; }
    public string Dosis { get; set; }
    public string DetalleConsumo { get; set; }
    public string Observacion { get; set; }
}