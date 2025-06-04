using DTOs;
using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.InterfacesCU.ICabaña;
using LogicaAplicacion.InterfacesCU.ITipoCabaña;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU.CabañaCU
{
    public class BuscarCabañaPorNombreCU : IBuscarCabañaPorNombreCU
    {
        private IRepositorioCabaña _repo;
        public BuscarCabañaPorNombreCU(IRepositorioCabaña repo)
        {
            _repo = repo;
        }

        public IEnumerable<CabañaDTO> BuscarPorNombre(string nombre)
        {
            try
            {
                return _repo.SearchByName(nombre).Select(c => new CabañaDTO(c));
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
