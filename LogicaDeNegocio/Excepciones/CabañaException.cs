using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Excepciones
{
    public class CabañaException:Exception
    {
        public CabañaException(){ }
        public CabañaException(string message) : base(message) { }
        public CabañaException(string message, Exception ex) : base(message,ex) { }

    }
}
