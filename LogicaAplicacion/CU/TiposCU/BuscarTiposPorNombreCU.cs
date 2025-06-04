using DTOs;
using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.InterfacesCU.ITipoCabaña;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU.TiposCU
{
    public class BuscarTiposPorNombreCU : IBuscarTiposPorNombreCU
    {
        private IRepositorioTCabaña _repo;
        public BuscarTiposPorNombreCU(IRepositorioTCabaña repo)
        {
            _repo = repo;
        }
        public IEnumerable<TipoCabañaDTO> BuscarPorNombreTipo(string nombre)
        {
            try
            {
                return _repo.SearchByName(nombre).Select(t => new TipoCabañaDTO(t));
            }
            catch (TCabañaException tce)
            {

                throw tce;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
