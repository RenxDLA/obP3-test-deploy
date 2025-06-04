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
    public class BuscarCabañaPorIdCU : IBuscarCabañaPorIdCU
    {
        private IRepositorioCabaña _repo;
        public BuscarCabañaPorIdCU(IRepositorioCabaña repo)
        {
            _repo = repo;
        }
        public CabañaDTO ObtenerPorId(int numeroCab)
        {
            try
            {
                return new CabañaDTO(_repo.Get(numeroCab));
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
