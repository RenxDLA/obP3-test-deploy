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
    public class DescripcionTCabaña: IValidable<DescripcionTCabaña>
    {
        public string Valor { get; protected set; }
        public DescripcionTCabaña() { }

        public DescripcionTCabaña(string valor)
        {
            Valor = valor;

        }
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new TCabañaException("La descripcion no puede estar vacía");
            }

            if (Valor.Length < configuracion.GetTopeInferiorByAtribute("DescTCab"))
            {
                throw new TCabañaException("La descripcion debe tener al menos "+ configuracion.GetTopeInferiorByAtribute("DescTCab"));
            }

            if (Valor.Length > configuracion.GetTopeSuperiorByAtribute("DescTCab"))
            {
                throw new TCabañaException("La descripcion debe tener como máximo " + configuracion.GetTopeSuperiorByAtribute("DescTCab"));
            }
        }
    }
}

