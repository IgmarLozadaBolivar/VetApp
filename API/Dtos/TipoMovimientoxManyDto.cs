using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TipoMovimientoxManyDto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public List<MovimientoMedicamentoDto> movimientoMedicamentos { get; set; }
    }
}