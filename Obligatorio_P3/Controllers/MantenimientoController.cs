using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using HotelDeCabañas.ValueObjects;
using LogicaAplicacion.InterfacesCU.ICabaña;
using LogicaAplicacion.InterfacesCU.IMantenimiento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MantenimientoController : Controller
    {
        //private IRepositorioMantenimiento _repo;
        //private IRepositorioCabaña _repoCab;
        private IBuscarCabañaPorIdCU _buscarCabPorId;
        private IRegistroMantenimientoCU _registro;
        private IObtenerMantenimientosPorIdCU _obtenerMantenimiento;
        private IObtenerMantnimientosEntreFechasCU _obtenerMantenimientoEntreFechas;
        private IBuscarEntreValoresCU _buscarEntreValores;

        //Se generan instancias de los Repositorios necesarios para realizar las operaciones.
        public MantenimientoController(
            //IRepositorioMantenimiento repo, 
            //IRepositorioCabaña repoCab,
            IBuscarCabañaPorIdCU buscarCabPorId,
            IRegistroMantenimientoCU registro,
            IObtenerMantenimientosPorIdCU obtenerMant,
            IObtenerMantnimientosEntreFechasCU obtenerMantFechas,
            IBuscarEntreValoresCU buscarEntreValores)
        {
            //this._repo = repo;
            //this._repoCab = repoCab;
            this._buscarCabPorId = buscarCabPorId;
            this._registro = registro;
            this._obtenerMantenimiento = obtenerMant;
            this._obtenerMantenimientoEntreFechas = obtenerMantFechas;
            this._buscarEntreValores = buscarEntreValores;


        }

        // GET: MantenimientoController
        public ActionResult Index(int nroHabitacion)
        {
            string idl = HttpContext.Session.GetString("LogueadoId");

            if (idl != null)
                //Se valida que el usuario esta logueado.
            {
                if (nroHabitacion != 0)
                {
                    ViewBag.Hab = nroHabitacion;

                }
                try
                {  
                   return View(_obtenerMantenimiento.ObtenerMantenimientos(nroHabitacion));
                }
                catch (MantenimientoException me)
                {
                    ViewBag.msg = me.Message;
                    return View ();
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.Message;
                    return View();
                }               
                 
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Index(DateTime d1, DateTime d2, int nroHab)
        {         

            try
            {
                //Se guarda Id en un ViewBag para mostrar en la vista en caso de que no llegue cargado.
                if (nroHab != 0) 
                {
                    ViewBag.Hab = nroHab;
                    
                }
                
                //Las validaciones se hacen en el repositorio.                
                var ms = _obtenerMantenimientoEntreFechas.MantenimientosPorFechas(d1, d2, nroHab).ToList();                
                return View(ms);
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View() ;
            }


        }

        // GET: MantenimientoController/Create
        public ActionResult Create(int nroHabitacion)
        {
            string idl = HttpContext.Session.GetString("LogueadoId");
            ViewBag.cab = _buscarCabPorId.ObtenerPorId(nroHabitacion);
            //Se valida que el usuario esta logueado.
            if (idl != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: MantenimientoController/Create
        [HttpPost]        
        public ActionResult Create(Mantenimiento m, int nroHabitacion, double costo)
        { 
            try
            {
                //Se carga el ViewBag para que no falle la vista.
                ViewBag.cab = _buscarCabPorId.ObtenerPorId(nroHabitacion);
                //Se asigna el numero de habitación.
                m.NroHabitacion = nroHabitacion;
                m.Costo = new Costo(costo);
                //Se hacen validaciones de la entidad en el repositorio correspondiente.
                _registro.Registrar(m);
                ViewBag.msg = "Alta Correcta.";               

            }
            catch (CabañaException ce)
            {
                ViewBag.msg = ce.Message;


            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View(m);
        }

        public ActionResult MantenimientosEntreValores() 
        {
            string idl = HttpContext.Session.GetString("LogueadoId");
            if (idl != null)
            //Se valida que el usuario esta logueado.
            {
                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
               
        }

        [HttpPost]
        public ActionResult MantenimientosEntreValores(int v1, int v2)
        {
            try
            {
                var m = _buscarEntreValores.GetBetweenValues(v1, v2);
                return View(m);
            }
            catch (MantenimientoException me) 
            {
                ViewBag.msg = me.Message;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return View();
                
            }
            

        }


    }
}
