using DTOs;
using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.InterfacesCU.ICabaña;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CU.CabañaCU
{
    public class BuscarCabañaPorTipoCU : IBuscarCabañaPorTipoCU
    {
        private IRepositorioCabaña _repo;
        public BuscarCabañaPorTipoCU(IRepositorioCabaña repo)
        {
            _repo = repo;
        }

        public IEnumerable<CabañaDTO> BuscarPorTipo(string tipo)
        {
            try
            {
                return _repo.SearchByType(tipo).Select(c => new CabañaDTO(c));
            }
            catch (CabañaException ce)
            {

                throw ce;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
