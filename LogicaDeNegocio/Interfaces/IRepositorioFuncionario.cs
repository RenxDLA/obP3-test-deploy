using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Interfaces
{
    public interface IRepositorioFuncionario:IRepositorio<Funcionario>
    {
        public Funcionario GetByEmail(string Email);
        public Funcionario Login(string email, string password);
       
    }
}
