using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EspeciexManyDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public List<MascotaDto> mascotas { get; set; }
        public List<RazaDto> razas { get; set; }
    }
}