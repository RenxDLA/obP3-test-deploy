using HotelDeCabañas.Entidades;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
//using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU.IFuncionario;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_P3.Models;
using System.Diagnostics;


namespace Obligatorio_P3.Controllers
{
    public class HomeController : Controller
    {

        private ILoginCU loginCU;
        //private IRepositorioFuncionario _repo;
        public HomeController(ILoginCU loginCU)
        {
            
            this.loginCU = loginCU;
        }
        
        public IActionResult Index()
        {
            return View();
        }     

         public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                // Las validaciones se realizan en el repositorio
                Funcionario fun = loginCU.Login(email, password);
                HttpContext.Session.SetString("LogueadoId", fun.Email);
                return RedirectToAction("Index");
            }
            catch (FuncionarioException fe)
            {
                ViewBag.msg = fe.Message;   
                return View();
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return View();
            }
            
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index");

        }



    }
}