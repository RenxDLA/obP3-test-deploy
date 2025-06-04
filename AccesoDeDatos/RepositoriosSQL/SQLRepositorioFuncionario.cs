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
    public class SQLRepositorioFuncionario : IRepositorioFuncionario
    {
        private HotelContext db = new HotelContext();

        public void Add(Funcionario item, IRepositorioConfiguracion configuracion)
        {
            try
            {
                //Valida que no haya usuario registrado con ese correo.
                if (db.funcionarios.Any(f => f.Email == item.Email)) 
                {
                    throw new FuncionarioException("Ya existe usuario asociado a ese correo");
                }
                //Llama al metodo validar de su entidad.
                item.Validar(configuracion);
                db.funcionarios.Add(item);
                //Se guardan los cambios en la base de datos.
                db.SaveChanges();
            }
            catch (FuncionarioException fe)
            {
                throw fe;
            }
            catch (Exception e)
            {
                throw e;
            }
        }        

        //Se implementa pero no se usa
        public void Delete(Funcionario item)
        {
            try
            {
                if (item == null)
                {
                    throw new FuncionarioException("El funcionario no puede ser vacío.");
                }

                db.funcionarios.Remove(item);
                db.SaveChanges();
            }
            catch (FuncionarioException fe)
            {

                throw fe;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //No se usa
        public Funcionario Get(int id)
        {
            throw new NotImplementedException();
        }
        //Retorna un funcionario a partir del email llegado por parámetros.
        public Funcionario GetByEmail(string Email)
        {
            try
            {
                Funcionario item = db.funcionarios.Where(f => f.Email == Email).FirstOrDefault();
                if (item == null) throw new FuncionarioException("Ingrese un correo valido");
                return item;
            }
            catch (FuncionarioException fe)
            {

                throw fe;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        //Se implementa pero no se usa
        public IEnumerable<Funcionario> GetAll()
        {
            try
            {
                return db.funcionarios.ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }


        //Se implementa pero no se usa
        public void Update(Funcionario item, IRepositorioConfiguracion configuracion)
        {
            try
            {
                if (item == null)
                {
                    throw new FuncionarioException("Los nuevos datos del funcionario que desea actualizar no pueden estar vacíos.");
                }
                
                Funcionario F= db.funcionarios.Where(f => f.Email == item.Email).FirstOrDefault();

                    F.Email= item.Email;
                    F.Password = item.Password; 
                    
                    db.SaveChanges();

                
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Funcionario Login(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) { throw new FuncionarioException("El correo no puede estar vacío"); }
                if (string.IsNullOrEmpty(password)) { throw new FuncionarioException("La contraseña no puede estar vacía"); }                
                var ret= db.funcionarios.Where(f => f.Email.ToLower() == email.ToLower() && f.Password.Valor == password).FirstOrDefault();
                if (ret == null) { throw new FuncionarioException("No existe usuario con esas credenciales, por favor intente de nuevo");}
                return ret;
            }
            catch (FuncionarioException fe)
            {

                throw fe;
            }
        }
    }
}
