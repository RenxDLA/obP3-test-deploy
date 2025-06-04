using HotelDeCabañas.Entidades;


namespace HotelDeCabañas.Interfaces
{
    public interface IRepositorioMantenimiento:IRepositorio<Mantenimiento>
    {        
        public IEnumerable<Mantenimiento> GetMantCabaña(int id);
        public IEnumerable<Mantenimiento> GetBetweenDates(DateTime d1, DateTime d2, int nroHab);
        public IEnumerable<NombreYmonto> GetBetweenValues(int v1, int v2);
    }
}
