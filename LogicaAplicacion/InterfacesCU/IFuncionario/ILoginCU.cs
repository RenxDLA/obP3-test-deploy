using HotelDeCabañas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.IFuncionario
{
    public interface ILoginCU
    {
        public Funcionario Login(string nombre, string pass);
    }
}
