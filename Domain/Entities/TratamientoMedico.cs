namespace Domain.Entities;

public class TratamientoMedico : BaseEntity
{
    public int IdCitaFK { get; set; }
    public Cita Cita { get; set; }
    public int IdMedicamentoFK { get; set; }
    public Medicamento Medicamento { get; set; }
    public string Dosis { get; set; }
    public string DetalleConsumo { get; set; }
    public string Observacion { get; set; } 
}