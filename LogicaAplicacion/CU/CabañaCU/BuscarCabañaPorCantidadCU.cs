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
    public class BuscarCabañaPorCantidadCU : IBuscarCabañaPorCantidadCU
    {
        private IRepositorioCabaña _repo;
        public BuscarCabañaPorCantidadCU(IRepositorioCabaña repo)
        {
            _repo = repo;
        }

        public IEnumerable<CabañaDTO> BuscarPorCantidad(int cant)
        {
            try
            {
                return _repo.SearchByCantidad(cant).Select(c => new CabañaDTO(c));
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
