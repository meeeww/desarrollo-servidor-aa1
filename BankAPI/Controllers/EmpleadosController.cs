using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosService _empleadoService;

        public EmpleadosController(EmpleadosService empleadosService)
        {
            _empleadoService = empleadosService;
        }

        [HttpGet]
        public IActionResult GetEmpleados()
        {
            try
            {
                return Ok(_empleadoService.GetEmpleados());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los empleados.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmpleadoById(int id)
        {
            try
            {
                var empleado = _empleadoService.GetEmpleadoById(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                return Ok(empleado);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el empleado." });
            }
        }

        [HttpPost]
        public IActionResult InsertEmpleado([FromBody] Empleado empleado)
        {
            try
            {
                if (empleado == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = _empleadoService.InsertEmpleado(empleado);

                return Created("Creado", created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateEmpleado([FromBody] Empleado empleado)
        {
            try
            {
                if (empleado == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _empleadoService.UpdateEmpleado(empleado);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmpleado(int id)
        {
            try
            {
                _empleadoService.DeleteEmpleado(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
