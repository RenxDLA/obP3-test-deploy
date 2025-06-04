using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelDeCabañas.ValueObjects
{
    [Owned]
    public class Contraseña : IValidable<Contraseña>
    {
        public string Valor { get; protected set; }

        public Contraseña(string valor)
        {
            Valor = valor;
        }
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            if (string.IsNullOrEmpty(Valor) || PasswordValido(configuracion) == false)
            {
                throw new FuncionarioException("La contraseña no puede ser null, debe tener minimo una minuscula, una mayuscula y largo mayor a 6 caracteres.");
            }
            
        }

        //public bool ValidarContraseña(string valor, IRepositorioConfiguracion config)
        //{
        //    // Requisitos de la contraseña: al menos 6 caracteres,
        //    // incluyendo una letra mayúscula, una letra minúscula y un dígito.
        //    string expresionRegular = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{"+config.GetTopeSuperiorByAtribute("Contraseña")+ ",}$";

        //    Regex regex = new Regex(expresionRegular);

        //    return regex.IsMatch(valor);
        //}
        
        public bool PasswordValido(IRepositorioConfiguracion config)
        {
            bool Mayuscula = false;
            bool Minuscula = false;
            bool Numero = false;
            for(int i =0; i < Valor.Length; i++)
            {
                if (Char.IsUpper(Valor[i]))
                {
                    Mayuscula = true;
                }
                else if (Char.IsLower(Valor[i]))
                {
                    Minuscula = true;
                }
                else if (Char.IsDigit(Valor[i]))
                {
                    Numero = true;
                }
                if(Mayuscula && Minuscula && Numero && Valor.Length >= config.GetTopeInferiorByAtribute("Contraseña") )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
