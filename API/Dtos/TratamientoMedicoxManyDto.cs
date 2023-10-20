using NodaTime;

namespace API.Dtos;

public class TratamientoMedicoxManyDto
{
    public int Id { get; set; }
    public CitaDto citas { get; set; }
    public MedicamentoDto medicamentos { get; set; }
    public string Dosis { get; set; }
    public LocalDateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }
}