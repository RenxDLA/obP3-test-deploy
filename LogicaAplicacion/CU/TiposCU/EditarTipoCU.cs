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
    public class EditarTipoCU : IEditarTipoCU
    {
        private IRepositorioTCabaña _repo;
        private IRepositorioConfiguracion _config;
        public EditarTipoCU(IRepositorioTCabaña repo, 
                            IRepositorioConfiguracion config)
        {
            _repo = repo;
            _config = config;
        }
        public TipoCabañaDTO editarTipo(TipoCabañaDTO tc)
        {
            try
            {
                TipoCabaña tipo = new TipoCabaña();
                tipo.NombreTipo = tc.NombreTipo;
                tipo.Descripcion = new HotelDeCabañas.ValueObjects.DescripcionTCabaña(tc.Descripcion);
                tipo.costoPorHuesped = tc.costoPorHuesped;
                _repo.Update(tipo, _config);
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
