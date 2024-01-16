using BankAPI.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVentasController : ControllerBase
    {
        private readonly IRegistroVentasRepository _registroVentasRepository;
        Logging logger = new Logging();

        public RegistroVentasController(IRegistroVentasRepository registroVentasRepository)
        {
            _registroVentasRepository = registroVentasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrosVentas()
        {
            try
            {
                return Ok(await _registroVentasRepository.GetRegistrosVentas());
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id={id}")]
        public async Task<IActionResult> GetRegistroVentasById(int id)
        {
            try
            {
                return Ok(await _registroVentasRepository.GetRegistroVentasById(id));
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("idEmpleado={id}")]
        public async Task<IActionResult> GetRegistroVentasByIdEmpleado(int id)
        {
            try
            {
                return Ok(await _registroVentasRepository.GetRegistroVentasById(id));
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
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

                var created = await _registroVentasRepository.InsertRegistroVentas(registroVentas);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
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

                await _registroVentasRepository.UpdateRegistroVentas(registroVentas);

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegistroVentas(int id)
        {
            try
            {
                await _registroVentasRepository.DeleteRegistroVentas(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
