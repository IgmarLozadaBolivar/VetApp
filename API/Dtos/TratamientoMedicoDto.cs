using Domain.Entities;
using NodaTime;
namespace API.Dtos;

public class TratamientoMedicoDto : BaseEntity
{
    public int IdCitaFK { get; set; }
    public int IdMedicamentoFK { get; set; }
    public string Dosis { get; set; }
    public LocalDateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }
}