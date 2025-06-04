using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Excepciones
{
    public class TCabañaException : Exception
    {
        public TCabañaException() { }
        public TCabañaException(string message) : base(message) { }
        public TCabañaException(string message, Exception ex) : base(message, ex) { }

    }
}
