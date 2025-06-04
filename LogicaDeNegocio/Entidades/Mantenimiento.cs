using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using HotelDeCabañas.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDeCabañas.Entidades
{
    public class Mantenimiento : IValidable<Mantenimiento>
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Costo Costo { get; set; }
        public string NombreEmpleado { get; set; }
        [ForeignKey(nameof(Cabaña))] public int NroHabitacion { get; set; }
        public Cabaña Cabaña { get; set; }


        public Mantenimiento(DateTime fecha, string descripcion, Costo costo, string nombreEmpleado)
        {            
            Fecha = fecha;
            Descripcion = descripcion;
            Costo = costo;
            NombreEmpleado = nombreEmpleado;            
        }

        public Mantenimiento()
        {
            Costo = new Costo();
        }
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            try
            {
                Costo.Validar(configuracion);
            }
            catch (MantenimientoException me)
            {

                throw me;
            }
            catch (Exception ex)
            {
                throw ex;
               
            }

            if (string.IsNullOrEmpty(Descripcion)) 
            {
                throw new MantenimientoException("La descripcion no puede ser vacía");
            }
            if (Descripcion.Length< configuracion.GetTopeInferiorByAtribute("DescMant"))
            {
                throw new MantenimientoException("La descripcion debe tener al menos "+ configuracion.GetTopeInferiorByAtribute("DescMant"));
            }
            if (Descripcion.Length > configuracion.GetTopeSuperiorByAtribute("DescMant")) 
            {
                throw new MantenimientoException("La descripcion puede tener como máximo "+ configuracion.GetTopeSuperiorByAtribute("DescMant"));
            }
            Costo.Validar(configuracion);
            //if (Costo <= 0) 
            //{
            //    throw new MantenimientoException("El costo debe ser mayor a 0.");
            //}
            if (string.IsNullOrEmpty(NombreEmpleado))
            {
                throw new MantenimientoException("El nombre del empleado no puede ser vacío.");
            }
            if(Fecha> DateTime.Now) 
            {
                throw new MantenimientoException("La fecha no puede ser mayor a la fecha de hoy.");
            }
        }
    }
}
