using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.IFuncionario
{
    public interface IObtenerFuncionarioCU
    {
        public FuncionarioDto ObtenerFuncionario(FuncionarioDto fun);
    }
}
