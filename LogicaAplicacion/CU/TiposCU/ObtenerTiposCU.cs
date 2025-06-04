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
    public class ObtenerTiposCU : IObtenerTiposCU
    {
        private IRepositorioTCabaña _repo;
        public ObtenerTiposCU(IRepositorioTCabaña repo)
        {
            _repo = repo;
        }
        public IEnumerable<TipoCabañaDTO> ObtenerTodosLosTipos()
        {
            try
            {
                return _repo.GetAll().Select(t=> new TipoCabañaDTO(t));
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
