using DTOs;
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
    public class ObtenerFuncionarioCU : IObtenerFuncionarioCU
    {
        private IRepositorioFuncionario _repo;
        public ObtenerFuncionarioCU(IRepositorioFuncionario repo)
        {
            _repo = repo;
        }

        public FuncionarioDto ObtenerFuncionario(FuncionarioDto fun)
        {
            try
            {
                FuncionarioDto retorno = new FuncionarioDto();
                Funcionario funcionario = _repo.GetByEmail(fun.Email);
                if (funcionario == null || fun.Password != funcionario.Password.Valor) 
                {
                    throw new Exception("Datos Incorrectos");
                }   
                retorno.Email = funcionario.Email;
                retorno.Password = funcionario.Password.Valor;
                return retorno;
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
