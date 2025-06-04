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

namespace LogicaAplicacion.CU.MantenimientoCU
{
    public class ObtenerMantenimientosPorIdCU : IObtenerMantenimientosPorIdCU
    {
        private IRepositorioMantenimiento _repo;
        public ObtenerMantenimientosPorIdCU(IRepositorioMantenimiento repo)
        {
            _repo = repo;
        }
        public IEnumerable<MantenimientoDTO> ObtenerMantenimientos(int nroCab)
        {
            try
            {
                return _repo.GetMantCabaña(nroCab).Select(m => new MantenimientoDTO(m));
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
