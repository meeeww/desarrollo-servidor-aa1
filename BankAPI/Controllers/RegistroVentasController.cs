using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVentasController : ControllerBase
    {
        private readonly IRegistroVentasRepository _registroVentasRepository;

        public RegistroVentasController(IRegistroVentasRepository registroVentasRepository)
        {
            _registroVentasRepository = registroVentasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrosVentas()
        {
            return Ok(await _registroVentasRepository.GetRegistrosVentas());
        }

        [HttpGet("id={id}")]
        public async Task<IActionResult> GetRegistroVentasById(int id)
        {
            return Ok(await _registroVentasRepository.GetRegistroVentasById(id));
        }

        [HttpGet("idEmpleado={id}")]
        public async Task<IActionResult> GetRegistroVentasByIdEmpleado(int id)
        {
            return Ok(await _registroVentasRepository.GetRegistroVentasById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistroVentas([FromBody] RegistroVentas registroVentas)
        {
            if (registroVentas == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _registroVentasRepository.InsertRegistroVentas(registroVentas);

            return Created("creado", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegistroVentas([FromBody] RegistroVentas registroVentas)
        {
            if (registroVentas == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _registroVentasRepository.UpdateRegistroVentas(registroVentas);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegistroVentas(int id)
        {
            await _registroVentasRepository.DeleteRegistroVentas(new RegistroVentas() { ID_RegistroVentas = id });

            return NoContent();
        }
    }
}
