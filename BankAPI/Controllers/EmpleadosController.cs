using BankAPI.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Data;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosService _empleadosService;
        private readonly ILoggingRepository _logger;

        public EmpleadosController(EmpleadosService empleadosService, ILoggingRepository logger)
        {
            _empleadosService = empleadosService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {

            try
            {
                return Ok(await _empleadosService.GetEmpleados());
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleadoById(int id)
        {

            try
            {
                var empleado = await _empleadosService.GetEmpleadoById(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmpleado([FromBody] Empleado empleado)
        {

            try
            {
                if (empleado == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = await _empleadosService.InsertEmpleado(empleado);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmpleado([FromBody] Empleado empleado)
        {

            try
            {
                if (empleado == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _empleadosService.UpdateEmpleado(empleado);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {

            try
            {
                await _empleadosService.DeleteEmpleado(id);

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
