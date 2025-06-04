using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Interfaces
{
    public interface IRepositorioTCabaña:IRepositorio<TipoCabaña>
    {
        public TipoCabaña GetByName(string name);
        public IEnumerable<TipoCabaña> SearchByName(string name);
    }
}
