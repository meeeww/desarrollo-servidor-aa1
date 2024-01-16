using BankAPI.Data.Services;
using BankAPI.Model;
using BankAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosRepository _empleadoRepository;
        private readonly ILoggingRepository _logger;

        public EmpleadosController(IEmpleadosRepository empleadoRepository, ILoggingRepository logger)
        {
            _empleadoRepository = empleadoRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {

            try
            {
                return Ok(await _empleadoRepository.GetEmpleados());
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
                return Ok(await _empleadoRepository.GetEmpleadoById(id));
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

                var created = await _empleadoRepository.InsertEmpleado(empleado);

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

                await _empleadoRepository.UpdateEmpleado(empleado);

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
                await _empleadoRepository.DeleteEmpleado(id);

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
