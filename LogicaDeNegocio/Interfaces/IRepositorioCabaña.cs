using HotelDeCabañas.Entidades;
using System.Diagnostics.Contracts;

namespace HotelDeCabañas.Interfaces
{
    public interface IRepositorioCabaña : IRepositorio<Cabaña>
    {
        //public void asignarNombreFoto(string foto);
        public Cabaña GetByName(string name);
        public IEnumerable<Cabaña> SearchByName(string name);
        public IEnumerable<Cabaña> SearchByCantidad(int cantidad);
        public IEnumerable<Cabaña> SearchByState();
        public IEnumerable<Cabaña> SearchByType(string nombreTipo);
        public IEnumerable<Cabaña> GetByTipoYMonto(string nomTipo, double monto);





    }
}
