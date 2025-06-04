using DTOs;
using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.IMantenimiento
{
    public interface IBuscarEntreValoresCU
    {
        public IEnumerable<NombreYmontoDTO> GetBetweenValues(int v1, int v2);
    }
}
