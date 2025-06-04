using DTOs;
using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICabaña
{
    public interface IBuscarPorTipoYMontoCU
    {
        public IEnumerable<CabañaDTO> BuscarPorTipoYMonto(string nomTipo, double monto);

    }
}
