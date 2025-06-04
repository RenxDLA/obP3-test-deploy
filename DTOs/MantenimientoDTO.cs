using HotelDeCabañas.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MantenimientoDTO
    {
        
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public string NombreEmpleado { get; set; }
        public int NroHabitacion { get; set; }
        public CabañaDTO Cabaña { get; set; }

        public MantenimientoDTO(){}

        public MantenimientoDTO(Mantenimiento mant)
        {
            this.Id = mant.Id;
            this.Fecha = mant.Fecha;
            this.Descripcion = mant.Descripcion;
            this.Costo = mant.Costo.Valor;
            this.NombreEmpleado = mant.NombreEmpleado;
            this.NroHabitacion = mant.NroHabitacion;
            this.Cabaña = new CabañaDTO(mant.Cabaña);
        }
    }
}
