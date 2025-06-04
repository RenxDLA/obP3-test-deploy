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
    public class ObtenerTodasLasCabañasCU : IObtenerTodasLasCabañasCU
    {
        private IRepositorioCabaña _repo;
        public ObtenerTodasLasCabañasCU(IRepositorioCabaña repo)
        {
            _repo = repo;
        }

        public IEnumerable<CabañaDTO> ObtenerTodas()
        {
            try
            {
                return _repo.GetAll().Select(c => new CabañaDTO(c));
            }
            catch (CabañaException ce)
            {

                throw ce;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
