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
    public class DescripcionCabaña : IValidable<DescripcionCabaña>
    {
        public string Valor { get; protected set; }
        public DescripcionCabaña() { }
        
        public DescripcionCabaña(string valor)
        {
            Valor = valor;
            
        }
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new CabañaException("La descripcion no puede estar vacía");
            }

            if(Valor.Length < configuracion.GetTopeInferiorByAtribute("DescCab") || Valor.Length > 500)
            {
                throw new CabañaException("La descripcion debe tener al menos "+ configuracion.GetTopeInferiorByAtribute("DescCab"));
            }

            if (Valor.Length > configuracion.GetTopeSuperiorByAtribute("DescCab"))
            {
                throw new CabañaException("La descripcion debe tener como maximo " + configuracion.GetTopeSuperiorByAtribute("DescCab"));
            }
        }
    }
}
