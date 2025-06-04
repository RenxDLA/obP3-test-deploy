using DTOs;
using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.InterfacesCU.IMantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CU.MantenimientoCU
{
    public class RegistroMantenimientoCU : IRegistroMantenimientoCU
    {
        private IRepositorioMantenimiento _repo;
        private IRepositorioCabaña _caba;
        private IRepositorioConfiguracion _config;
        public RegistroMantenimientoCU( IRepositorioCabaña caba,
                                        IRepositorioMantenimiento repo, 
                                       IRepositorioConfiguracion config)
        {
            _repo = repo;
            _config = config;
            _caba = caba;
        }

        public MantenimientoDTO AddMantenimiento(MantenimientoDTO mant)
        {
            try
            {
                Mantenimiento mantAgregado = new Mantenimiento();
                mantAgregado.Fecha = mant.Fecha;
                mantAgregado.Descripcion = mant.Descripcion;
                mantAgregado.Costo = new HotelDeCabañas.ValueObjects.Costo(mant.Costo); 
                mantAgregado.NombreEmpleado = mant.NombreEmpleado;
                mantAgregado.NroHabitacion = mant.NroHabitacion;
                
                _repo.Add(mantAgregado, _config);
                return new MantenimientoDTO(_repo.Get(mantAgregado.Id));
            }
            catch (MantenimientoException me)
            {

                throw me;
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }
    }
}
