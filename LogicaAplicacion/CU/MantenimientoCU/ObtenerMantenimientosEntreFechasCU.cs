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
    public class ObtenerMantenimientosEntreFechasCU : IObtenerMantnimientosEntreFechasCU
    {
        private IRepositorioMantenimiento _repo;
        public ObtenerMantenimientosEntreFechasCU(IRepositorioMantenimiento repo)
        {
            _repo = repo;
        }
        public IEnumerable<MantenimientoDTO> MantenimientosPorFechas(DateTime f1, DateTime f2, int nroHab)
        {
            try
            {
                return _repo.GetBetweenDates(f1, f2, nroHab).Select(m => new MantenimientoDTO(m));
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
