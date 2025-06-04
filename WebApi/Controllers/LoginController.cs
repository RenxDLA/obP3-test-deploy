using DTOs;
using LogicaAplicacion.InterfacesCU.IFuncionario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration configuracion { get; set; }
        private ManejadorJwt ManejadorJwt { get; set; }
        public LoginController(IConfiguration configuration, IObtenerFuncionarioCU obtenerFuncionario)
        {
            this.ManejadorJwt = new ManejadorJwt(obtenerFuncionario);
            this.configuracion = configuration;
        }

        /// <summary>
        /// Metodo para conseguir Token dado un usuario
        /// </summary>
        /// <param name="Funcionario">Credenciales de usuario que desea iniciar sesion</param>
        /// <returns>Token generado</returns>
        [HttpPost("")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<FuncionarioDto> Login([FromBody] FuncionarioDto funcionarioActual)
        {
            try
            {                
                var fun = ManejadorJwt.ObtenerFuncionario(funcionarioActual);

                var token = ManejadorJwt.GenerarToken(fun, configuracion);

                return Ok(new
                {
                    Token = token,
                    Funcionario = fun
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
