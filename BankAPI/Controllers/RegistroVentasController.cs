using BankAPI.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Data;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVentasController : ControllerBase
    {
        private readonly RegistroVentasService _registroVentasService;
        private readonly ILoggingRepository _logger;

        public RegistroVentasController(RegistroVentasService registroVentasService, ILoggingRepository logger)
        {
            _registroVentasService = registroVentasService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrosVentas()
        {
            try
            {
                return Ok(await _registroVentasService.GetRegistrosVentas());
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id={id}")]
        public async Task<IActionResult> GetRegistroVentasById(int id)
        {
            try
            {
                var registroVentas = await _registroVentasService.GetRegistroVentasById(id);
                if (registroVentas == null)
                {
                    return NotFound();
                }
                return Ok(registroVentas);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("idEmpleado={id}")]
        public async Task<IActionResult> GetRegistroVentasByIdEmpleado(int id)
        {
            try
            {
                var registroVentas = await _registroVentasService.GetRegistroVentasById(id);
                if (registroVentas == null)
                {
                    return NotFound();
                }
                return Ok(registroVentas);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistroVentas([FromBody] RegistroVentas registroVentas)
        {
            try
            {
                if (registroVentas == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = await _registroVentasService.InsertRegistroVentas(registroVentas);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegistroVentas([FromBody] RegistroVentas registroVentas)
        {
            try
            {
                if (registroVentas == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _registroVentasService.UpdateRegistroVentas(registroVentas);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegistroVentas(int id)
        {
            try
            {
                await _registroVentasService.DeleteRegistroVentas(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
