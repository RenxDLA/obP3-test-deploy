using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CabañaDTO
    {
        public string NombreTipo { get; set; }
        public TipoCabañaDTO tipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NroHabitacion { get; set; }
        public bool tieneJacuzzi { get; set; }
        public bool estaHabilitada { get; set; }
        public int cantMax { get; set; }
        public string Foto { get; set; }
        public CabañaDTO() { }

        public CabañaDTO(Cabaña cab)
        {
            this.NombreTipo = cab.NombreTipo;
            this.tipo = new TipoCabañaDTO(cab.tipo);
            this.Nombre = cab.Nombre;
            this.Descripcion = cab.Descripcion.Valor;
            this.NroHabitacion = cab.NroHabitacion;
            this.tieneJacuzzi = cab.tieneJacuzzi;
            this.estaHabilitada = cab.estaHabilitada;
            this.cantMax = cab.cantMax;
            this.Foto = cab.Foto;
        }
    }
}
