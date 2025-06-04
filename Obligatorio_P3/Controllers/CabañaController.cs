using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
//using para poder cargar las imagenes
using Microsoft.AspNetCore.Mvc;
using HotelDeCabañas.Interfaces;
using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.IdentityModel.Tokens;
using HotelDeCabañas.ValueObjects;
using LogicaAplicacion.InterfacesCU.ICabaña;
using LogicaAplicacion.InterfacesCU.ITipoCabaña;

namespace Web.Controllers
{

    public class CabañaController : Controller
    {
        //private IRepositorioCabaña _repo;
        //private IRepositorioTCabaña _tcaba;
        private IWebHostEnvironment _enviro;
        private IObtenerTiposCU _obtenerTiposCU;
        private IRegistroCabañaCU _registroCU;
        private IObtenerTodasLasCabañasCU _obtenerCabañasCU;
        private IBuscarCabañaPorNombreCU _buscarPorNombreCU;
        private IBuscarCabañaPorTipoCU _buscarPorTipoCU;
        private IBuscarCabañaPorCantidadCU _buscarPorCantidadCU;
        private IBuscarCabañasHabilitadasCU _buscarHabilitadasCU;        

        public CabañaController(IRepositorioCabaña repo,
            /*IRepositorioTCabaña repo2*/            
            IWebHostEnvironment environment,
            IRegistroCabañaCU registroCU,
            IObtenerTiposCU _obtenerTiposCU,
            IObtenerTodasLasCabañasCU obtenerCabañasCU,
            IBuscarCabañaPorNombreCU buscarPorNombreCU,
            IBuscarCabañaPorTipoCU buscarPorTipoCU,
            IBuscarCabañaPorCantidadCU buscarPorCantidadCU,
            IBuscarCabañasHabilitadasCU buscarHabilitadasCU)
        {
            //this._repo = repo;
            //this._tcaba = repo2;
            this._enviro = environment;            
            this._registroCU = registroCU;
            this._obtenerTiposCU = _obtenerTiposCU;
            this._obtenerCabañasCU = obtenerCabañasCU;
            this._buscarPorNombreCU = buscarPorNombreCU;
            this._buscarPorTipoCU = buscarPorTipoCU;
            this._buscarPorCantidadCU = buscarPorCantidadCU;
            this._buscarHabilitadasCU = buscarHabilitadasCU;
        }

       

        // GET: CabañaController
        public ActionResult Index()
        {
            string idl = HttpContext.Session.GetString("LogueadoId");
            //Verifica que el usuario este loguedo.
            if (idl != null)
            {
                //Verifica que hayan cabañas para mostrar.
                if (_obtenerCabañasCU.ObtenerTodas().ToList().Count > 0)
                {
                    //Se guarda la lista de todas los tipos de cabañas.
                    IEnumerable<TipoCabaña> tc = _obtenerTiposCU.ObtenerTodosLosTipos();
                    ViewBag.tipoNombres = tc;
                    return View(_obtenerCabañasCU.ObtenerTodas().ToList());
                }
                else
                {
                    ViewBag.msg = "No hay cabañas disponibles para mostrar.";
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Index(string Nombre, int CantMax, string NombreTipo)
        {
            //Se guarda la lista de todas los tipos de cabañas.
            IEnumerable<TipoCabaña> tc = _obtenerTiposCU.ObtenerTodosLosTipos();
            ViewBag.tipoNombres = tc;

            try
            {  //Las validaciones se hacen en el repositorio.

                //Creo una lista para guardar el retorno de cada busqueda, para retornarlo a la vista.
                IEnumerable<Cabaña> c = new List<Cabaña>();

                //Si el parametro a buscar es Nombre, se ejecuta la busqueda por nombre.
                if (!string.IsNullOrEmpty(Nombre))
                {
                     c = _buscarPorNombreCU.BuscarPorNombre(Nombre);
                    
                        return View(c);
                }
                //Si el parametro a buscar es Cantidad máxima, se ejecuta la busqueda por cantidad.
                if (CantMax != 0)
                {
                    c = _buscarPorCantidadCU.BuscarPorCantidad(CantMax);
                    return View(c);  
                }
                //Si el parametro a buscar es nombre de tipo, se ejecuta la busqueda por nombre de tipo.
                if (!string.IsNullOrEmpty(NombreTipo))
                {
                    c = _buscarPorTipoCU.BuscarPorTipo(NombreTipo);
                    return View(c);
                }


                throw new CabañaException("No hay cabañas con ese criterio.");
                

            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View();

        }

        // GET: CabañaController/Create
        public ActionResult Create()
        {
            string idl = HttpContext.Session.GetString("LogueadoId");

            if (idl != null)
            {
                //Se guarda la lista de todos los tipos de cabañas.
                IEnumerable<TipoCabaña> tc = _obtenerTiposCU.ObtenerTodosLosTipos();
                ViewBag.tipoNombres = tc;
                return View();
            }

            return RedirectToAction("Index", "Home");

        }

        // POST: CabañaController/Create
        [HttpPost]

        public ActionResult Create(Cabaña c, string NombreTipo, IFormFile img, string desc)
        {
            IEnumerable<TipoCabaña> tc = _obtenerTiposCU.ObtenerTodosLosTipos();
            ViewBag.tipoNombres = tc;

            try
            {                 
                    c.NombreTipo = NombreTipo;
                    GuardarImagen(img, c);
                    c.Descripcion = new DescripcionCabaña(desc);
                    //agrega la imagen al modelo
                    //Se valida en el repositorio
                    _registroCU.AddCabaña(c);
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
            return View();

        }
        
        private void GuardarImagen(IFormFile img, Cabaña c)
        {
            
            if (img == null || c == null) throw new CabañaException("Imagen no cargada");
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _enviro.WebRootPath;
            
            //Se valida el formato de la imagen
            string format = img.FileName.Split('.').Last();
            if (format != "jpg" && format != "png" && format != "JPG" && format != "PNG") throw new CabañaException("La imagen debe ser un archivo .jpg o .png");

            //Se valida que la foto subida corresponda a la cabaña que se esta dando de alta
            string nombreImagen = c.NombrarImagen() + "_001." + format;    
            //if (!nombreImagen.Contains(c.Nombre)) throw new CabañaException("La imagen no pertenece a esta cabaña");
            
            //ruta donde se guardan las fotos de las cabañas
            string rutaFisicaFoto = Path.Combine
            (rutaFisicaWwwRoot, "imagenes", "fotos", nombreImagen);
            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar 
                using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {
                    //Para archivos grandes o varios archivos usar la versión
                    //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                    img.CopyTo(f);
                }
                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                c.Foto = nombreImagen;
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

        
        public ActionResult CabañasHabilitadas()
        {
            string idl = HttpContext.Session.GetString("LogueadoId");
            //Verifica que el usuario esta logueado.
            if (idl != null)
            {
                try 
                {
                    //Retorna a la vista las cabañas que estan habilitadas.
                    return View(_buscarHabilitadasCU.BuscarHabilitadas().ToList());
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.Message;
                    return View();
                }
                
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
