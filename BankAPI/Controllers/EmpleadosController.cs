using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosRepository _empleadoRepository;

        public EmpleadosController(IEmpleadosRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            return Ok(await _empleadoRepository.GetEmpleados());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleadoById(int id)
        {
            return Ok(await _empleadoRepository.GetEmpleadoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _empleadoRepository.InsertEmpleado(empleado);

            return Created("creado", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _empleadoRepository.UpdateEmpleado(empleado);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            await _empleadoRepository.DeleteEmpleado(new Empleado() { ID_Empleado = id });

            return NoContent();
        }
    }
}
