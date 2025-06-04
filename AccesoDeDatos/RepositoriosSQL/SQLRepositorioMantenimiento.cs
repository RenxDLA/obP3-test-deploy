using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AccesoDeDatos.RepositoriosSQL
{
    public class SQLRepositorioMantenimiento : IRepositorioMantenimiento
    {
        private HotelContext db = new HotelContext();
        public void Add(Mantenimiento item, IRepositorioConfiguracion configuracion)
        {
            try
            {
                //Llama al metodo validar de su entidad.
                item.Validar(configuracion);
                //Consulta linq para verificar que no hay más de 3 mantenimientos con la misma fecha.
                int cantMant = db.mantenimientos.Where(m => m.NroHabitacion == item.NroHabitacion && m.Fecha == item.Fecha).ToList().Count();
                if (cantMant >= 3) 
                {
                    throw new MantenimientoException("No se pueden agregar mas mantenimientos en este día");  
                }
                db.mantenimientos.Add(item);
                //Se guardan los cambios en la base de datos.
                db.SaveChanges();
            }
            catch (MantenimientoException me)
            {

                throw me;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Se implementa pero no se utiliza este método.
        public void Delete(Mantenimiento item)
        {
            throw new NotImplementedException();
        }
        
        public Mantenimiento Get(int id)
        {
            try
            {
                if (id==null)
                {
                    throw new MantenimientoException("Ingrese un id valido");
                }
                Mantenimiento m = db.mantenimientos.Where(m => m.Id == id).Include(m => m.Cabaña).Include(m => m.Cabaña.tipo).FirstOrDefault();
                if (m==null) throw new MantenimientoException("No existe manteniento con ese id");
                return m; 
            }
            catch (MantenimientoException me)
            {

                throw me;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        //Se implementa pero no se utiliza este método.
        public IEnumerable<Mantenimiento> GetAll()
        {
            throw new NotImplementedException ();
            
        }

        public IEnumerable<Mantenimiento> GetBetweenDates(DateTime d1, DateTime d2, int nroHab)
        {
            try
            {
                //Si las fechas llegan desordenadas se asigna correctamente.
                DateTime mayor;
                DateTime menor;
                if (d1 >= d2)
                {
                    mayor = d1;
                    menor = d2;
                }
                else
                {
                    mayor = d2;
                    menor = d1;
                }

                //Se valida que los parametros no esten vacíos.
                if (nroHab == 0) 
                { 
                    throw new MantenimientoException("El numero de cabaña no puede ser vacío"); 
                }
                if (d1 == new DateTime(0001, 01, 01) || d2 == new DateTime(0001, 01, 01)) 
                { 
                    throw new MantenimientoException("Las fechas no puede ser vacías"); 
                }

                var ret = db.mantenimientos.Where(m => m.NroHabitacion == nroHab && m.Fecha >= d1 && m.Fecha <= d2).Include(m => m.Cabaña).Include(m => m.Cabaña.tipo).OrderByDescending(m => m.Costo.Valor).ToList();
                //Se valida que no llegue vacía la lista.
                if (ret.Count == 0) 
                { 
                    throw new MantenimientoException("No hay mantenimientos entre esas fechas para esta cabaña"); 
                }
                return ret;
            }
            catch (MantenimientoException me) 
            {
                throw me;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public IEnumerable<Mantenimiento> GetMantCabaña(int id)
        {
            try
            {
                //Se valida que hayan mantenimientos para mostrar y los ordena descendentemente por costo.
                var ret = db.mantenimientos.Where(m => m.NroHabitacion == id).Include(m => m.Cabaña).Include(m => m.Cabaña.tipo).OrderByDescending(m => m.Costo.Valor).ToList();
                if (ret.Count == 0)
                {
                    throw new MantenimientoException("No hay mantenimientos realizados en esta cabaña.");
                }
                return ret;

            }
            catch (MantenimientoException me)
            {
                throw me;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        //Se implementa pero no se utiliza este método.
        public void Update(Mantenimiento item, IRepositorioConfiguracion configuracion)
        {
            throw new NotImplementedException();
        }

        /*---------------------------NUEVA CONSULTA--------------------------*/

        public IEnumerable<NombreYmonto> GetBetweenValues(int v1, int v2)
        {
            try
            {
                int mayor;
                int menor;
                if (v1 > v2)
                {
                    mayor = v1;
                    menor = v2;
                }
                else
                {
                    mayor = v2;
                    menor = v1;
                }
                var preRet = db.mantenimientos.Include(m => m.Cabaña).Include(m => m.Cabaña.tipo)
                        .Where(m => m.Cabaña.cantMax < mayor && m.Cabaña.cantMax > menor)
                        .GroupBy(m => m.NombreEmpleado);

                IEnumerable<NombreYmonto> ret = preRet.Select(g => new NombreYmonto
                {
                    NombreEmpleado = g.Key,
                    MontoTotal = g.Sum(m => m.Costo.Valor)
                }).ToList();
                if(ret == null)
                {
                    throw new MantenimientoException("No hay mantenimientos que cumplan estas condiciones.");
                }
                return ret;

            }
            catch(MantenimientoException me)
            {
                throw me;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
    }

}
