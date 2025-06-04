using DTOs;
using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.InterfacesCU.ICabaña;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU.CabañaCU
{
    public class BuscarPorTipoYMontoCU : IBuscarPorTipoYMontoCU
    {
        private IRepositorioCabaña _repo;
        public BuscarPorTipoYMontoCU(IRepositorioCabaña repo)
        {
            _repo = repo;
        }
        public IEnumerable<CabañaDTO> BuscarPorTipoYMonto(string nomTipo, double monto)
        {
            try
            {                
                return _repo.GetByTipoYMonto(nomTipo, monto).Select(c => new CabañaDTO(c));
            }
            catch (CabañaException ce) 
            { 
                throw ce; 
            } 
            catch (Exception e)
            {

                throw e;
            }
        }
        
    }
}
