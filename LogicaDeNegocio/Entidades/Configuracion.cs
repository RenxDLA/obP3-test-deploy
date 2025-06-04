using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeCabañas.Entidades
{
    public class Configuracion
    {
        [Key]
        public string Atributo { get; set; }
        public int LimiteSuperior { get; set; }
        public int LimiteInferior { get; set; }
    }
}
