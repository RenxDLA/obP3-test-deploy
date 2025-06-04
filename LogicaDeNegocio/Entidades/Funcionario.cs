using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using HotelDeCabañas.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace HotelDeCabañas.Entidades
{
    public class Funcionario : IValidable<Funcionario>
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public Contraseña Password { get; set; }
        

        public Funcionario(string email, Contraseña password)
        {
            Email = email;
            Password = password;    
        }

        public Funcionario()
        {
            
        }
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            if (string.IsNullOrEmpty(Email) || EmailValido(Email) == false)
            {
                throw new FuncionarioException("Debe introducir una dirección de correo valida.");
            }
            //if(string.IsNullOrEmpty(Password) || PasswordValido(Password)==false)
            //{
            //    throw new FuncionarioException("La contraseña no puede ser null, debe tener minimo una minuscula, una mayuscula y ser mayor a 6 caracteres.");
            //}
        }
        public bool EmailValido(string mail) 
        {
            string arroba = "@";
            int pos = mail.IndexOf(arroba);
            if (pos == -1 || pos == 0 || pos == mail.Length - 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public bool PasswordValido(string password)
        //{
        //    bool Mayuscula = false;
        //    bool Minuscula = false;
        //    bool Numero = false;
        //    for(int i =0; i < Password.Length; i++)
        //    {
        //        if (Char.IsUpper(Password[i]))
        //        {
        //            Mayuscula = true;
        //        }
        //        else if (Char.IsLower(Password[i]))
        //        {
        //            Minuscula = true;
        //        }
        //        else if (Char.IsDigit(Password[i]))
        //        {
        //            Numero = true;
        //        }
        //        if(Mayuscula && Minuscula && Numero && password.Length >= 6)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        
    }
}
