using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class NombreYmontoDTO
    {
        public string NombreEmpleado { get; set; }
        public double MontoTotal { get; set; }

        public NombreYmontoDTO(NombreYmonto nym)
        {
            this.NombreEmpleado = nym.NombreEmpleado;
            this.MontoTotal = nym.MontoTotal;
        }
       
    }
}
