using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using HotelDeCabañas.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelDeCabañas.Entidades
{
    //[Index(nameof(Nombre), IsUnique=true)]
    public class TipoCabaña : IValidable<TipoCabaña>
    {
        [Key]   
        public string NombreTipo { get; set; }
        public DescripcionTCabaña Descripcion { get; set; }
        public double costoPorHuesped { get; set; }

        public TipoCabaña(string nombreTipo, DescripcionTCabaña descripcion, double costoPorHusped)
        {
            NombreTipo= nombreTipo;
            Descripcion= descripcion;
            costoPorHuesped= costoPorHusped;
        }

        public TipoCabaña()
        {
            
        }

        public void Validar(IRepositorioConfiguracion configuracion)
        {
            if(string.IsNullOrEmpty(NombreTipo) || ValidarNombre(NombreTipo) == false)
            {
                throw new TCabañaException("El nombre de la cabaña no puede ser vacío.");
            }
            Descripcion.Validar(configuracion);
            //if (string.IsNullOrEmpty(Descripcion) || Descripcion.Length < 10 || Descripcion.Length > 200)
            //{
            //    throw new TCabañaException("La descripcion no puede ser nula y debe tener entre 10 y 200 caracteres.");
            //}
            if (costoPorHuesped<=configuracion.GetTopeInferiorByAtribute("CostoTCab"))
            {
                throw new TCabañaException("El costo debe ser mayor a $"+ configuracion.GetTopeInferiorByAtribute("CostoTCab"));
            }
            if (!ValidarNombre(NombreTipo))
            {
                throw new TCabañaException("No puede contener espacios o caracteres que no sean alfabeticos.");
            }

        }

        private bool ValidarNombre(string nombre)
        {
            string n = nombre.ToUpper();
            string trimmedName = n.Trim();
            for (int i = 0; i < n.Length; i++)
            {
                char c = n[i];
                int valorASCII = (int)c;
                if (valorASCII != 209 && valorASCII != 32 && (valorASCII < 65 || valorASCII > 90))
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
    }
}
