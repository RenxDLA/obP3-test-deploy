﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Excepciones
{
    public class FuncionarioException:Exception
    {
        public FuncionarioException() { }
        public FuncionarioException(string message) : base(message) { }
        public FuncionarioException(string message, Exception ex) : base(message, ex) { }
    }
}
