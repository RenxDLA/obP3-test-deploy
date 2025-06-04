using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using HotelDeCabañas.ValueObjects;
using LogicaAplicacion.InterfacesCU.ITipoCabaña;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Core.Types;

namespace Web.Controllers
{
    public class TipoCabañaController : Controller
    {
        private IAltaDeTCabañaCU _AltaCU;
        private IObtenerTiposCU _ObtenerTiposCU;
        private IBuscarTiposPorNombreCU _BuscarPorNombreCU;
        private IObtenerTipoPorNombre _ObtenerPorNombreCU;
        private IBorrarTipoCU _BorrarTipoCU;
        private IEditarTipoCU _EditarTipoCU;
        public TipoCabañaController(
            IRepositorioTCabaña repo, 
            IAltaDeTCabañaCU altaCU, 
            IObtenerTiposCU obtenerTiposCU, 
            IBuscarTiposPorNombreCU buscarPorNombreCU, 
            IObtenerTipoPorNombre obtenerPorNombreCU,
            IBorrarTipoCU borrarTipoCU, 
            IEditarTipoCU editarTipoCU)
        {
            
            this._AltaCU = altaCU;
            this._ObtenerTiposCU = obtenerTiposCU;
            this._BuscarPorNombreCU = buscarPorNombreCU;
            this._ObtenerPorNombreCU = obtenerPorNombreCU;
            this._BorrarTipoCU = borrarTipoCU;
            this._EditarTipoCU = editarTipoCU;
        }
        // GET: TipoCabañaController
        public ActionResult Index()
        {
            string idl = HttpContext.Session.GetString("LogueadoId");
            //Verifica que el usuario esta logueado.
            if (idl != null)
            {
                //Verifica que hayan tipos de cabaña para mostrar en la vista.
                if (_ObtenerTiposCU.ObtenerTodosLosTipos().ToList().Count > 0)
                {
                    return View(_ObtenerTiposCU.ObtenerTodosLosTipos().ToList());
                }
                else
                {
                    ViewBag.msg = "No hay tipos de cabañas disponibles para mostrar.";
                    return View();
                }
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Index(string nombreTipo)
        {
            try
            {
                //Se guarda los tipos de cabañas a partir del nombre que le llegó por parámetros.
                IEnumerable<TipoCabaña> tp = _BuscarPorNombreCU.BuscarPorNombreTipo(nombreTipo);
                return View(tp);
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View();

        }

        // GET: TipoCabañaController/Create
        public ActionResult Create()
        {
            string idl = HttpContext.Session.GetString("LogueadoId");

            //Verifica que el usuario esta logueado.
            if (idl != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: TipoCabañaController/Create
        [HttpPost]
       
        public ActionResult Create(TipoCabaña tp, string desc)
        {
                try
                {
                //Las validaciones se hacen en la entidad.
                    tp.Descripcion = new DescripcionTCabaña(desc);
                    _AltaCU.AltaCabaña(tp);
                    ViewBag.msg = "Alta Correcta.";
                }
                catch (TCabañaException tce)
                {
                    ViewBag.msg = tce.Message;


                }
                catch (Exception e)
                {
                    ViewBag.msg = e.Message;


                }
            return View();

        }

        // GET: TipoCabañaController/Edit/5
        public ActionResult Edit(string NombreTipo)
        {
            string idl = HttpContext.Session.GetString("LogueadoId");

            //Verifica que el usuario esta logueado.
            if (idl != null)
            {
                //Guarda el tipo con el nombre que llega por parámetro.
                TipoCabaña tipo = _ObtenerPorNombreCU.ObtenerTipoPorNombre(NombreTipo);
                return View(tipo);
            }
            return RedirectToAction("Index", "Home");   
                
        }

        // POST: TipoCabañaController/Edit/5
        [HttpPost]       
        public ActionResult Edit(TipoCabaña tipo, string desc)
        {
            try
            {
                tipo.Descripcion = new DescripcionTCabaña(desc);
                _EditarTipoCU.editarTipo(tipo);
                ViewBag.msg = "Datos actualizados correctamente.";
                return View(tipo);
            }
            catch(Exception e)
            {
                ViewBag.msg = e.Message;
                return View(tipo);
            }
        }

        // GET: TipoCabañaController/Delete/5
        public ActionResult Delete(string NombreTipo)
        {
            string idl = HttpContext.Session.GetString("LogueadoId");

            //Verifica que el usuario esta logueado.
            if (idl != null)
            {
                TipoCabaña buscada = _ObtenerPorNombreCU.ObtenerTipoPorNombre(NombreTipo);            
                
                    try
                    {
                        _BorrarTipoCU.Borrar(buscada);
                        ViewBag.msg = "Cabaña eliminada exitosamente.";
                        return View(buscada);
                    }
                    catch (Exception ex)
                    {

                        ViewBag.msg = ex.Message;

                    }
                                    

                return View(buscada);
            }

            return RedirectToAction("Index", "Home");

        }

        
    }
}
