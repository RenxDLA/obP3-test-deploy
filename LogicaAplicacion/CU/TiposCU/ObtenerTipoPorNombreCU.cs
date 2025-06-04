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
    public class ObtenerTipoPorNombreCU : IObtenerTipoPorNombre
    {
        private IRepositorioTCabaña _repo;
        public ObtenerTipoPorNombreCU(IRepositorioTCabaña repo)
        {
            _repo = repo;
        }
        public TipoCabañaDTO ObtenerTipoPorNombre(string nombre)
        {
            try
            {
                return new TipoCabañaDTO(_repo.GetByName(nombre));
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
