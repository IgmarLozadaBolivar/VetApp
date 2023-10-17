namespace API.Dtos;

public class DetalleMovimientoxManyDto
{
    public string Id { get; set; }
    public MedicamentoDto medicamentos { get; set; }
    public int Cantidad { get; set; }
    public MovimientoMedicamentoDto movimientoMedicamentos { get; set; }
    public decimal Precio { get; set; }
}
