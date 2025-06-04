using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccesoDeDatos.RepositoriosSQL
{
    public class SQLRepositorioCabaña : IRepositorioCabaña
    {
        private HotelContext db = new HotelContext();
        
        public void Add(Cabaña item, IRepositorioConfiguracion configuracion)
        {
            try
            {
                //Valida que no haya guardada una cabaña con el mismo Nombre.
                if (db.cabañas.Any(c => c.Nombre == item.Nombre))
                {
                    throw new CabañaException("Ya existe una cabaña con ese nombre");
                }
                
                //Llama al metodo validar de su entidad.
                item.Validar(configuracion);
                db.cabañas.Add(item);
                //Se guardan los cambios en la base de datos.
                db.SaveChanges();
            }
            catch (CabañaException ce)
            {
                throw ce;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

     

        public void Delete(Cabaña item)
        {
            try
            {
                if(item == null)
                {
                    throw new CabañaException("La cabaña no puede ser vacia");
                }

                db.cabañas.Remove(item);
                //Se guardan los cambios en la base de datos.
                db.SaveChanges();
            }
            catch (CabañaException ce)
            {

                throw ce;
            }
            catch(Exception e) 
            {
                throw e;
            }
            
        }

        public Cabaña Get(int id)
        {
            //Retorna al controller la cabaña que tenga el mismo Id pasado por parametro.
            return db.cabañas.Where(c => c.NroHabitacion == id).Include(c=> c.tipo).FirstOrDefault();
        }

        public IEnumerable<Cabaña> GetAll()
        {
            try
            {
                //Retorna la lista de todas las cabañas.
                var ret = db.cabañas.Include(c => c.tipo).ToList();
                if (ret.Count() == 0) throw new CabañaException("No hay cabañas disponibles.");
                return ret;
            }
            catch (CabañaException ce) 
            {
                throw ce;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cabaña GetByName(string name)
        {
            if(name != null)
            {
                //Retorna al controller las cabañas que tengan el mismo nombre pasado por parámetros.
                return db.cabañas.Where(c=>c.Nombre==name).Include(c => c.tipo).FirstOrDefault();
            }
            else 
            {
                throw new Exception("Nombre no puede estar vacío.");
            }
            
        }

        public IEnumerable<Cabaña> GetTipos()
        {
            return db.cabañas.Include(c => c.tipo).ToList();
        }

        //Se implementa pero no se usa.
        public void Update(Cabaña item, IRepositorioConfiguracion configuracion)
        {
            throw new NotImplementedException();
        }

        //Retorna una lista de cabañas a partir del nombre llegado por parámetros.
        public IEnumerable<Cabaña> SearchByName(string name)
        {
            var resultado = db.cabañas.Where(c => c.Nombre.Contains(name)).Include(c => c.tipo).ToList();
            if (resultado.Count() == 0)
            {
                throw new CabañaException("No existe cabaña con ese nombre.");
            }
            if (name == null)
            {
                throw new CabañaException("El nombre no puede estar vacío.");
            }
            return resultado;
        }

        //Retorna una lista de cabañas a partir de la cantidad llegada por parámetros.
        public IEnumerable<Cabaña> SearchByCantidad(int cantidad)
        {
            //Retorna la lista de cabañas donde su cantidad maxima es la misma que la cantidad que le llega por parámetros.
            var resultado = db.cabañas.Where(c => c.cantMax >= cantidad).Include(c => c.tipo).ToList();
            if (resultado.Count()==0)
            {
                throw new CabañaException("No hay ninguna cabaña que tenga esa capacidad.");
            }
            if (cantidad == 0)
            {
                throw new CabañaException("La cantidad no puede estar vacía.");
            }
            return resultado;
        }

        //Retorna una lista de cabañas a partir del estado llegado por parámetros.
        public IEnumerable<Cabaña> SearchByState()
        {
            var resultado = db.cabañas.Where(c => c.estaHabilitada).Include(c => c.tipo).ToList();            
            if (resultado.Count() == 0)
            {
                throw new CabañaException("No hay ninguna cabaña habilitada.");
            }
            
            return resultado;
        }

        //Retorna una lista de cabañas a partir del tipo llegado por parámetros.
        public IEnumerable<Cabaña> SearchByType(string nombreTipo)
        {
            var resultado = db.cabañas.Include(c=>c.tipo).Where(c => c.tipo.NombreTipo == nombreTipo).ToList();
            if (resultado.Count() == 0)
            {
                throw new CabañaException("No hay ninguna cabaña de ese tipo.");
            }
            if (nombreTipo == null)
            {
                throw new CabañaException("El nombre de tipo no puede estar vacío.");
            }
            return resultado;
        }

        /*---------------------------NUEVA CONSULTA--------------------------*/
        
        public IEnumerable<Cabaña> GetByTipoYMonto(string nomTipo, double monto)
        {
            try
            {
                
                IEnumerable<Cabaña> ret= db.cabañas.Include(c => c.tipo).Where(c => c.NombreTipo == nomTipo && c.tipo.costoPorHuesped < monto
                                                       && c.tieneJacuzzi && c.estaHabilitada).ToList();
                if (ret.Count() == 0)
                {
                    throw new CabañaException("No hay cabañas que cumplan estas condiciones.");
                }
                return ret;
            }
            catch (CabañaException ce)
            {
                throw ce;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
