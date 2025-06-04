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

namespace LogicaAplicacion.CU.CabañaCU
{
    public class RegistroCabañaCU : IRegistroCabañaCU
    {
        private IRepositorioCabaña _repo;
        private IRepositorioTCabaña _tcab;
        private IRepositorioConfiguracion _config;
        public RegistroCabañaCU(IRepositorioCabaña repo, 
                                IRepositorioConfiguracion configuracion,
                                IRepositorioTCabaña tcab)
        {
            _repo = repo;
            this._config = configuracion;
            _tcab = tcab;
        }

        public CabañaDTO AddCabaña(CabañaDTO cab)
        {
            try
            {
                Cabaña cabAgregada = new Cabaña();
                cabAgregada.NombreTipo = cab.NombreTipo;                
                cabAgregada.Nombre = cab.Nombre;
                cabAgregada.Descripcion = new HotelDeCabañas.ValueObjects.DescripcionCabaña(cab.Descripcion);
                cabAgregada.tieneJacuzzi = cab.tieneJacuzzi;
                cabAgregada.estaHabilitada = cab.estaHabilitada;
                cabAgregada.cantMax = cab.cantMax;
                cabAgregada.Foto = cab.Foto;
                _repo.Add(cabAgregada, _config);
                return new CabañaDTO(_repo.Get(cabAgregada.NroHabitacion));
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
