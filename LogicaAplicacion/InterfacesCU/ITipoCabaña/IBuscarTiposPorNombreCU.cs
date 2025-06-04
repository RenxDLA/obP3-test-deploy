using DTOs;
using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ITipoCabaña
{
    public interface IBuscarTiposPorNombreCU
    {
        public IEnumerable<TipoCabañaDTO> BuscarPorNombreTipo(string nombre);
    }
}
