using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TipoCabañaDTO
    {
        public string NombreTipo { get; set; }
        public string Descripcion { get; set; }
        public double costoPorHuesped { get; set; }
        public TipoCabañaDTO() { }

        public TipoCabañaDTO(TipoCabaña tipo)
        {
            this.NombreTipo = tipo.NombreTipo;
            this.Descripcion = tipo.Descripcion.Valor;
            this.costoPorHuesped = tipo.costoPorHuesped;
        }
    }
}
