using BE_WebAPI_Vehiculos.Common.Dtos;
using BE_WebAPI_Vehiculos.Repository.Entities;
using BE_WebAPI_Vehiculos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_WebAPI_Vehiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly BdvehiculosContext _context;
        private IVehiculoServices _iVehiculoServices;
        private VehiculosDto _vehiculosDto;
        private VehiculoDto _vehiculoDto;

        public VehiculoController(BdvehiculosContext context, IVehiculoServices iVehiculoServices)
        {
            this._context= context;
            this._iVehiculoServices= iVehiculoServices;
        }

        /// <summary>
        /// Get lista completa con todos los datos de Vehículo
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get lista")]        
        public async Task<IActionResult> Get1()
        {
            try
            {
                _vehiculosDto = await _iVehiculoServices.ObtenerVehiculos().ConfigureAwait(false);
                if (_vehiculosDto != null)
                {
                    return Ok(JsonConvert.SerializeObject(_vehiculosDto));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get que utiliza una Vista SQL
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get Vista SQL")]
        public async Task<IActionResult> Get2()
        {
            try
            {
                _vehiculosDto = await _iVehiculoServices.ObtenerVehiculosVista().ConfigureAwait(false);
                if (_vehiculosDto != null)
                {
                    return Ok(JsonConvert.SerializeObject(_vehiculosDto));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        
        /// <summary>
        /// Get con Procedimiento Almacenado SQL. Muestra los vehículos que tienen un stock menor al ingresado por parámetro.
        /// </summary>
        /// <param name="stockMenor"></param>
        /// <returns></returns>
        [HttpGet("Get con Procedimiento Almacenado SQL")]
        public async Task<IActionResult> Get3(int stockMenor)
        {
            try
            {                
                var lista = await _context.Vehiculos.FromSqlRaw($"EXECUTE dbo.VehiculosPorStockMenor {stockMenor}").ToListAsync();                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<VehiculoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _vehiculoDto = await _iVehiculoServices.ObtenerVehiculoPorId(id).ConfigureAwait(false);
                if(_vehiculoDto != null)
                {
                    return Ok(_vehiculoDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<VehiculoController>
        [HttpPost]        
        public async Task<IActionResult> Post([FromBody] VehiculoDto vehiculoDto)
        {
            try
            {
                return Ok(await _iVehiculoServices.CrearVehiculo(vehiculoDto).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<VehiculoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehiculoDto vehiculoDto)
        {
            try
            {
                if(id != vehiculoDto.Id)
                {
                    return NotFound();
                }

                return Ok(await _iVehiculoServices.ModificarVehiculo(vehiculoDto).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<VehiculoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {                
                return Ok(await _iVehiculoServices.BorrarVehiculo(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }
    }
}
