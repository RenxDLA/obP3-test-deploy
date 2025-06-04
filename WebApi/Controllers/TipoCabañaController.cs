using DTOs;
using HotelDeCabañas.Excepciones;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.InterfacesCU.ITipoCabaña;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TipoCabañaController : Controller
    {
        private IAltaDeTCabañaCU _AltaCU;
        private IObtenerTiposCU _ObtenerTiposCU;
        private IBuscarTiposPorNombreCU _BuscarPorNombreCU;
        private IObtenerTipoPorNombre _ObtenerPorNombreCU;
        private IBorrarTipoCU _BorrarTipoCU;
        private IEditarTipoCU _EditarTipoCU;
        private string _uri = "http://localhost:5218";
        public TipoCabañaController(
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

        /// <summary>
        /// Se obtienen todos los tipos de cabaña que hay en la base de datos.
        /// </summary>
        /// <returns>Todos los tipos</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetTipos()
        {
            try
            {
                return Ok(_ObtenerTiposCU.ObtenerTodosLosTipos());
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
        /// Se agrega un nuevo tipo de Cabaña.
        /// </summary>
        /// <param name="tipo">Tipo a agregar</param>
        /// <returns>El tipo creado</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Post([FromBody] TipoCabañaDTO tipo)
        {
            try
            {
                return Created(new Uri(_uri + "/TipoCabana"), _AltaCU.AltaCabaña(tipo));
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
        /// Se obtiene un solo tipo a partir de su nombre.
        /// </summary>
        /// <param name="name">Nombre a buscar</param>
        /// <returns>Tipo con el nombre que se busco</returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetByName(string name)
        {
            try
            {
                return Ok(_ObtenerPorNombreCU.ObtenerTipoPorNombre(name));
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
        /// Se realiza busqueda de los tipos a partir de su nombre.
        /// </summary>
        /// <param name="name">Contenido a buscar en los nombres de los tipos</param>
        /// <returns>Lista de tipos</returns>
        [HttpGet("Filter/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult SearchByName(string name)
        {
            try
            {
                return Ok(_BuscarPorNombreCU.BuscarPorNombreTipo(name));
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
        /// Se modifican los datos nuevos en el tipo ya existente.
        /// </summary>
        /// <param name="tipo">Los nuevo datos</param>
        /// <returns>El tipo modificado</returns>
        [HttpPut("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Put([FromBody] TipoCabañaDTO tipo, string name)
        {
            try
            {
                return Ok(_EditarTipoCU.editarTipo(tipo));
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

        // DELETE api/<CabañaController>/5
        /// <summary>
        /// Se elimina el tipo indicado de la base de datos.
        /// </summary>
        /// <param name="name">Id del tipo a eliminar</param>
        /// <returns>El tipo eliminado</returns>
        [HttpDelete("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Delete(string name)
        {
            try
            {
                return Ok(_BorrarTipoCU.Borrar(name));
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
