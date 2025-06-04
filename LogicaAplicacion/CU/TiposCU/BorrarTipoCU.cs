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
    public class BorrarTipoCU : IBorrarTipoCU
    {
        private IRepositorioTCabaña _repo;
        public BorrarTipoCU(IRepositorioTCabaña repo)
        {
            _repo = repo;
        }

        public TipoCabañaDTO Borrar(string tc)
        {
            try
            {
                TipoCabaña tipo = _repo.GetByName(tc);
                _repo.Delete(tipo);
                return new TipoCabañaDTO(tipo);
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
