using DTOs;
using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.IMantenimiento
{
    public interface IObtenerMantnimientosEntreFechasCU
    {
        public IEnumerable<MantenimientoDTO> MantenimientosPorFechas(DateTime f1, DateTime f2, int nroHab);
    }
}
