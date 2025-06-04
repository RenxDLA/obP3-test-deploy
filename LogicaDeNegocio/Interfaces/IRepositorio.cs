using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public void Add(T item, IRepositorioConfiguracion config);
        public void Update(T item, IRepositorioConfiguracion config);
        public void Delete(T item);
        public T Get(int id);
        public IEnumerable<T> GetAll();
        
    }
}
