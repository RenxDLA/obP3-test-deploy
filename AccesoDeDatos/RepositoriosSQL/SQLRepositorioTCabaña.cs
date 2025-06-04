using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.RepositoriosSQL
{
    public class SQLRepositorioTCabaña : IRepositorioTCabaña
    {
        private HotelContext db = new HotelContext();


        public void Add(TipoCabaña item, IRepositorioConfiguracion configuracion)
        {
            try
            {
                //Verifica que no haya una cabaña guardada con el mismo nombre.
                if (db.tipos.Any(tc => tc.NombreTipo == item.NombreTipo))
                {
                    throw new TCabañaException("Ya existe un tipo de cabaña con ese nombre");
                }
                if (item == null)
                {
                    throw new TCabañaException("Los datos no pueden estar vacíos.");
                }
                //Llama al metodo validar de su entidad.
                item.Validar(configuracion);
                db.tipos.Add(item);
                //Se guardan los cambios en la base de datos.
                db.SaveChanges();
            }
            catch (TCabañaException tce)
            {

                throw tce;
            }
            catch(Exception e) 
            {
                throw e;     
            }
        }

        public void Delete(TipoCabaña item)
        {
            try
            {
                if (item == null)
                {
                    throw new TCabañaException("El tipo de cabaña que desea elminar no puede ser vacío");
                }
                //Verifica que el tipo de cabaña que se quiere eliminar no este en uso.
                if (db.cabañas.Any(c => c.NombreTipo == item.NombreTipo))
                {
                    throw new TCabañaException("El tipo de cabaña que desea elminar esta en uso");
                }
                db.tipos.Remove(item);
                //Se guardan los cambios en la base de datos.
                db.SaveChanges ();
            }
            catch (TCabañaException tce)
            {

                throw tce;
            }
        }

        
        public TipoCabaña GetByName(string name)
        {
            //Retorna el tipo de cabaña que tiene el mismo nombre que llega por parametros.
            var resultado= db.tipos.Where(tc => tc.NombreTipo.Equals(name)).FirstOrDefault();
            if (resultado == null)
            {
                throw new TCabañaException("El nombre de tipo de cabaña que busco no existe.");
            }
            return resultado;
            
        }

        //No se usa.
        public TipoCabaña Get(int id)
        {
            throw new NotImplementedException();
        }

        //Retorna la lista de todos los tipos de cabañas.
        public IEnumerable<TipoCabaña> GetAll()
        {
            return db.tipos.ToList();
        }

        
        public void Update(TipoCabaña item, IRepositorioConfiguracion configuracion)
        {
            try
            {
                
                if (item == null)
                {
                    throw new TCabañaException("Los nuevos datos del tipo de cabaña que desea actualizar no pueden estar vacíos.");
                }

                item.Validar(configuracion);
                //Retorna el tipo de cabaña para actualizrla a partir de su nombre.
                TipoCabaña TC = db.tipos.Where(tp => tp.NombreTipo == item.NombreTipo).FirstOrDefault();

                if (item.Descripcion != null)
                {
                    TC.Descripcion= item.Descripcion;
                }
                if (item.costoPorHuesped != null) 
                {
                    TC.costoPorHuesped= item.costoPorHuesped;
                }

                //Se guardan los cambios en la base de datos.
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<TipoCabaña> SearchByName(string name)
        {
            //Retorna una lista de cabañas a partir de el nombre que le llega por parametros.
            var resultado = db.tipos.Where(tc => tc.NombreTipo.Contains(name)).ToList();
            if (string.IsNullOrEmpty(name))
            {
                throw new TCabañaException("El nombre de tipo no puede estar vacío.");
            }
            if (resultado.Count() == 0)
            {
                throw new TCabañaException("El nombre de tipo de cabaña que busco no existe.");
            }
            return resultado;
        }
        
    }
}
