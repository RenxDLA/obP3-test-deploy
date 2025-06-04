using DTOs;
using HotelDeCabañas.Excepciones;
using LogicaAplicacion.InterfacesCU.ICabaña;
using LogicaAplicacion.InterfacesCU.IMantenimiento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MantenimientoController : ControllerBase
    {        
        private IRegistroMantenimientoCU _registro;
        private IObtenerMantenimientosPorIdCU _obtenerMantenimiento;
        private IObtenerMantnimientosEntreFechasCU _obtenerMantenimientoEntreFechas;
        private IBuscarEntreValoresCU _buscarEntreValores;
        private string _uri = "http://localhost:5218";

        //Se generan instancias de los Repositorios necesarios para realizar las operaciones.
        public MantenimientoController(
            IBuscarCabañaPorIdCU buscarCabPorId,
            IRegistroMantenimientoCU registro,
            IObtenerMantenimientosPorIdCU obtenerMant,
            IObtenerMantnimientosEntreFechasCU obtenerMantFechas,
            IBuscarEntreValoresCU buscarEntreValores)
        {            
            this._registro = registro;
            this._obtenerMantenimiento = obtenerMant;
            this._obtenerMantenimientoEntreFechas = obtenerMantFechas;
            this._buscarEntreValores = buscarEntreValores;


        }
        /// <summary>
        /// Se obtiene el mantenimiento con el numero de cabaña indicado.
        /// </summary>
        /// <param name="id">Numero de la cabaña con el mantenimiento a buscar</param>
        /// <returns>El mantenimiento con el id ingresado</returns>
        [HttpGet("{nroCab}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetById(int nroCab)
        {
            try
            {
                return Ok(_obtenerMantenimiento.ObtenerMantenimientos(nroCab));
            }
            catch (MantenimientoException me)
            {
                return BadRequest(me.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Se agrega un nuevo Mantenimiento.
        /// </summary>
        /// <param name="mant">MantenimientoDTO</param>
        /// <returns>Devuelve un DTO del mantenimiento creado</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Post([FromBody] MantenimientoDTO mant)
        {
            try
            {
                return Created(_uri + "/Mantenimiento", _registro.AddMantenimiento(mant));
            }
            catch (MantenimientoException me)
            {
                return BadRequest(me.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Se realiza busqueda de los matenimientos de acuerdo a dos capacidades.
        /// </summary>
        /// <param name="Valor">Mantenimientos realizados que esten dentro de dos montos</param>
        /// <returns>Lista de cabañas filtradas</returns>
        [HttpGet("Filter/Capacidad/{cap1}; {cap2}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetBetweenValues(int cap1, int cap2)
        {
            try
            {
                return Ok(_buscarEntreValores.GetBetweenValues(cap1, cap2));
            }
            catch (MantenimientoException me)
            {

                return BadRequest(me.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Se realiza busqueda de los matenimientos realizados entre dos fechas dadas.
        /// </summary>
        /// <param name="Fechas">Mantenimientos realizados que esten dentro de estas dos fechas</param>
        /// <returns>Lista de cabañas filtradas</returns>
        [HttpGet("Filter/Dates/{fch1}; {fch2}; {nroHab}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetBetweenDates(DateTime fch1, DateTime fch2, int nroHab)
        {
            try
            {
                return Ok(_obtenerMantenimientoEntreFechas.MantenimientosPorFechas(fch1, fch2, nroHab));
            }
            catch (MantenimientoException me)
            {

                return BadRequest(me.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
