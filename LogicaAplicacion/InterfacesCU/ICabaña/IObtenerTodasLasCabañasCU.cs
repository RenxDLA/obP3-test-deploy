using DTOs;
using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICabaña
{
    public interface IObtenerTodasLasCabañasCU
    {
        public IEnumerable<CabañaDTO> ObtenerTodas();
    }
}
