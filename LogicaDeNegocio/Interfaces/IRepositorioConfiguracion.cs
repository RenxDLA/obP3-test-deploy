using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Interfaces
{
    public interface IRepositorioConfiguracion:IRepositorio<Configuracion>
    {
        public int GetTopeInferiorByAtribute(string name);
        public int GetTopeSuperiorByAtribute(string name);
    }
}
