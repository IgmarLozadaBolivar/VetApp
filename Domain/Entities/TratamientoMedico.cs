using NodaTime;

namespace Domain.Entities;

public class TratamientoMedico : BaseEntity
{
    public int IdCitaFK { get; set; }
    public Cita Citas { get; set; }
    public int IdMedicamentoFK { get; set; }
    public Medicamento Medicamentos { get; set; }
    public string Dosis { get; set; }
    public LocalDateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; } 
}