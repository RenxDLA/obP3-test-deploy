using HotelDeCabañas.Entidades;
using HotelDeCabañas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.RepositoriosSQL
{
    public class SQLRepositorioConfiguracion : IRepositorioConfiguracion
    {
        private HotelContext db = new HotelContext();
        public void Add(Configuracion item, IRepositorioConfiguracion configuracion)
        {
            throw new NotImplementedException();
        }

        public void Delete(Configuracion item)
        {
            throw new NotImplementedException();
        }

        public Configuracion Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Configuracion> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetTopeInferiorByAtribute(string name)
        {
            Configuracion config = db.configuraciones.Where(config => config.Atributo == name).FirstOrDefault();
            if (config == null) { throw new Exception("Atributo invalido."); }
            return config.LimiteInferior;
        }

        public int GetTopeSuperiorByAtribute(string name)
        {
            Configuracion config = db.configuraciones.Where(config => config.Atributo == name).FirstOrDefault();
            if (config == null) { throw new Exception("Atributo invalido."); }
            return config.LimiteSuperior;
        }

        public void Update(Configuracion item, IRepositorioConfiguracion configuracion)
        {
            throw new NotImplementedException();
        }
    }
}
