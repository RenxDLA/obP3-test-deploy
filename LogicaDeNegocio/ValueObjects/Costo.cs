using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.ValueObjects
{
    [Owned]
    public class Costo : IValidable<Costo>
    {
        public double Valor { get; protected set; }

        public Costo( double valor)
        {
            this.Valor = valor;
        }
        public Costo() { this.Valor = 0; }
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            {
            if (Valor <= configuracion.GetTopeInferiorByAtribute("CostoMant"))
                throw new MantenimientoException("El costo debe ser mayor a $"+ configuracion.GetTopeInferiorByAtribute("CostoMant"));
            }
        }
    }
}
