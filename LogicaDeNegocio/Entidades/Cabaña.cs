using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using HotelDeCabañas.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDeCabañas.Entidades
{
    [Index(nameof(Nombre), IsUnique=true)]
    public class Cabaña : IValidable<Cabaña>
    {
        [ForeignKey(nameof(tipo))] public string NombreTipo { get; set; }
        public TipoCabaña tipo { get; set; }
        public string Nombre { get; set; }
        public DescripcionCabaña Descripcion { get; set; }
        [Key]
        public int NroHabitacion { get; set; }
        public bool tieneJacuzzi { get; set; }
        public bool estaHabilitada { get; set; }
        public int cantMax { get; set; }
        public string Foto { get; set; }

        public Cabaña(TipoCabaña Tipo, string nombre, DescripcionCabaña descripcion,  bool TieneJacuzzi, bool EstaHabilitada, int CantMax, string foto)
        {
            tipo = Tipo;
            Nombre = nombre;
            Descripcion = descripcion;            
            tieneJacuzzi = TieneJacuzzi;
            estaHabilitada = EstaHabilitada;
            cantMax = CantMax;
            Foto = foto;

        }

        public Cabaña()
        {
            
        }

        public void Validar(IRepositorioConfiguracion configuracion)
        {
            try
            {
                Descripcion.Validar(configuracion);
            }
            catch (CabañaException ce)
            {

                throw ce;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            //if(String.IsNullOrEmpty(Descripcion) || Descripcion.Length<10 || Descripcion.Length > 500)
            //{
            //    throw new CabañaException("La descripcion debe tener entre 10 y 500 caracteres.");
            //}
            if (String.IsNullOrEmpty(Nombre) || ValidarNombre(Nombre)==false)
            {
                throw new CabañaException("El nombre de la cabaña no puede tener espacios y solo debe incluir caracteres alfabeticos");
            }
            if(cantMax <= configuracion.GetTopeInferiorByAtribute("cantMaxCabaña")) 
            {
                throw new CabañaException("La capacidad debe ser mayor a " + configuracion.GetTopeInferiorByAtribute("cantMaxCabaña")); 
            }  
            if(string.IsNullOrEmpty(NombreTipo)) 
            { 
                throw new CabañaException("Debe seleccionar un tipo valido"); 
            }
            
        }

        public bool ValidarNombre(String nombre)
        {
            
            string n = nombre.ToUpper();
            string trimmedName = n.Trim();
            for (int i = 0; i < n.Length; i++)
            {
                char c = n[i];
                int valorASCII = (int)c;
                if (valorASCII != 209 && valorASCII!=32 && (valorASCII < 65 || valorASCII > 90) )
                {
                    return false;
                }
                
            }
            if (n == trimmedName)
            {
                return true;
            }
            return true;
        }

        public string NombrarImagen()
        {
            if (String.IsNullOrEmpty(Nombre)) {
                throw new CabañaException("El nombre de la cabaña no puede ser vacio");
            }
            
            if (this.Nombre.Contains(' '))
            {
                return  this.Nombre.Replace(' ', '_');
            }
            else {
                return this.Nombre;
            }
        }
    }
}
