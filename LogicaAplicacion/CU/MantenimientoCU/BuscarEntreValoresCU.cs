using DTOs;
using HotelDeCabañas.Entidades;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.InterfacesCU.IMantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU.MantenimientoCU
{
    public class BuscarEntreValoresCU : IBuscarEntreValoresCU
    {
        private IRepositorioMantenimiento _repo;
        public BuscarEntreValoresCU(IRepositorioMantenimiento repo)
        {
            _repo = repo;
        }

        public IEnumerable<NombreYmontoDTO> GetBetweenValues(int v1, int v2)
        {
            return _repo.GetBetweenValues(v1, v2).Select(nym => new NombreYmontoDTO(nym));
        }
    }
}
