using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Interfaces
{
    public interface IValidable<T>
    {
        public void Validar(IRepositorioConfiguracion configuracion);
    }
}
