using DTOs;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.CU.TiposCU;
using LogicaAplicacion.InterfacesCU.ICabaña;
using LogicaAplicacion.InterfacesCU.ITipoCabaña;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CabañaController : ControllerBase
    {
        private IRegistroCabañaCU _registroCU;
        private IObtenerTodasLasCabañasCU _obtenerCabañasCU;
        private IBuscarCabañaPorNombreCU _buscarPorNombreCU;
        private IBuscarCabañaPorTipoCU _buscarPorTipoCU;
        private IBuscarCabañaPorCantidadCU _buscarPorCantidadCU;
        private IBuscarCabañasHabilitadasCU _buscarHabilitadasCU;
        private IBuscarCabañaPorIdCU _buscarPorId;
        private IBuscarPorTipoYMontoCU _buscarPorTipoYMonto;
        private string _uri = "http://localhost:5218";
        public CabañaController(
            IRegistroCabañaCU registroCU,
            IObtenerTodasLasCabañasCU obtenerCabañasCU,
            IBuscarCabañaPorNombreCU buscarPorNombreCU,
            IBuscarCabañaPorTipoCU buscarPorTipoCU,
            IBuscarCabañaPorCantidadCU buscarPorCantidadCU,
            IBuscarCabañasHabilitadasCU buscarHabilitadasCU,
            IBuscarCabañaPorIdCU buscarPorId,
            IBuscarPorTipoYMontoCU buscarPorTipoYMonto)
        {
            this._registroCU = registroCU;
            this._obtenerCabañasCU = obtenerCabañasCU;
            this._buscarPorNombreCU = buscarPorNombreCU;
            this._buscarPorTipoCU = buscarPorTipoCU;
            this._buscarPorCantidadCU = buscarPorCantidadCU;
            this._buscarHabilitadasCU = buscarHabilitadasCU;
            this._buscarPorId = buscarPorId;
            _buscarPorTipoYMonto = buscarPorTipoYMonto;
        }

        /// <summary>
        /// Se obtiene la cabaña con el numero de habitacion indicado por parametros.
        /// </summary>
        /// <param name="id">Numero de la cabaña a buscar</param>
        /// <returns>La cabaña con el numero de habitacion ingresado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetById(int id) 
        {
            try
            {
                return Ok(_buscarPorId.ObtenerPorId(id));
            }
            catch (CabañaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CabañaController>
        /// <summary>
        /// Se agrega una nueva Cabaña.
        /// </summary>
        /// <param name="cab">Un objeto cabaña</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Post([FromBody] CabañaDTO cab)
        {
            try
            {
                return Created(_uri+"/Cabana", _registroCU.AddCabaña(cab));
            }
            catch (CabañaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return CreatedAtRoute("", new { id = 0}, null);
        }

        /// <summary>
        /// Se obtienen todas las cabañas de la base de datos.
        /// </summary>
        /// <returns>Lista con las cabañas</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetCabañas()
        {
            try
            {
                return Ok(_obtenerCabañasCU.ObtenerTodas());
            }
            catch (CabañaException cex)
            {

                return BadRequest(cex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Se realiza una busqueda de cabañas segun su nombre.
        /// </summary>
        /// <param name="name">Contenido a buscar en los nombres de las cabañas</param>
        /// <returns>Lista de cabañas filtradas</returns>
        [HttpGet("Filter/Name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult SearchByName(string name)
        {
            try
            {
                return Ok(_buscarPorNombreCU.BuscarPorNombre(name));
            }
            catch (TCabañaException tex)
            {

                return BadRequest(tex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Se realiza una busqueda de cabañas segun su tipo.
        /// </summary>
        /// <param name="type">Nombre del tipo a buscar</param>
        /// <returns>Lista de cabañas filtradas</returns>
        [HttpGet("Filter/Type/{type}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult SearchByType(string type) 
        {            
           
            try
            {
                return Ok(_buscarPorTipoCU.BuscarPorTipo(type));
            }
            catch (TCabañaException tex)
            {

                return BadRequest(tex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Se realiza una busqueda de cabañas segun su capacidad.
        /// </summary>
        /// <param name="cantidad">La cantidad necesaria para filtrar</param>
        /// <returns>Lista de cabañas filtradas</returns>
        [HttpGet("Filter/Cantidad/{cantidad}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult SearchByCantidad(int cantidad)
        {
            try
            {
                return Ok(_buscarPorCantidadCU.BuscarPorCantidad(cantidad));
            }
            catch (TCabañaException tex)
            {

                return BadRequest(tex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Se realiza una busqueda de las cabañas habilitadas.
        /// </summary>        
        /// <returns>Lista de cabañas habilitadas</returns>
        [HttpGet("Filter/Estado/Habilitada")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult SearchByState()
        {
            try
            {
                return Ok(_buscarHabilitadasCU.BuscarHabilitadas());
            }
            catch (TCabañaException tex)
            {

                return BadRequest(tex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Se realiza busqueda de cabañas de acuerdo al monto y tipo.
        /// </summary>
        /// <param name="cantidad">El monto y el tipo por el cual filtraremos</param>
        /// <returns>Lista de cabañas filtradas</returns>
        [HttpGet("Filter/{type}; {monto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult SearchByTipoYMonto(string type, double monto) 
        {
            
            try
            {
                return Ok(_buscarPorTipoYMonto.BuscarPorTipoYMonto(type, monto));
            }
            catch (TCabañaException tex)
            {

                return BadRequest(tex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
