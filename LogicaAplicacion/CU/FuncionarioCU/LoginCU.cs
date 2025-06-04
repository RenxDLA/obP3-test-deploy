using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.InterfacesCU.IFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU.FuncionarioCU
{
    public class LoginCU : ILoginCU
    {
        private IRepositorioFuncionario _repo;
        public LoginCU(IRepositorioFuncionario repo)
        {
            _repo = repo;
        }

        public Funcionario Login(string nombre, string pass)
        {
            try
            {
                return _repo.Login(nombre, pass);
            }
            catch (FuncionarioException fe)
            {
                throw fe;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
