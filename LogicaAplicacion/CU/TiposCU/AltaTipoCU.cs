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
    public class AltaTipoCU : IAltaDeTCabañaCU
    {
        private IRepositorioTCabaña _repo;
        private IRepositorioConfiguracion _config;
        public AltaTipoCU(IRepositorioTCabaña repo, IRepositorioConfiguracion config)
        {
            _repo = repo;
            _config = config;
        }

        public TipoCabañaDTO AltaCabaña(TipoCabañaDTO tp)
        {
            try
            {
                TipoCabaña tipoAgregado = new TipoCabaña(tp.NombreTipo,new HotelDeCabañas.ValueObjects.DescripcionTCabaña(tp.Descripcion), tp.costoPorHuesped);                
                _repo.Add(tipoAgregado, _config);
                return new TipoCabañaDTO(_repo.GetByName(tp.NombreTipo));
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
