using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVentasController : ControllerBase
    {
        private readonly RegistroVentasService _registroVentasService;

        public RegistroVentasController(RegistroVentasService registroVentasService)
        {
            _registroVentasService = registroVentasService;
        }

        [HttpGet]
        public IActionResult GetRegistroVentas()
        {
            try
            {
                return Ok(_registroVentasService.GetRegistrosVentas());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los registro de ventas." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroVentasById(int id)
        {
            try
            {
                var cliente = _registroVentasService.GetRegistroVentasById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el registro de venta." });
            }
        }

        [HttpGet("empleado={id}")]
        public IActionResult GetRegistroVentasByIdEmpleado(int id)
        {
            try
            {
                var cliente = _registroVentasService.GetRegistroVentasByIdEmpleado(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el registro de venta." });
            }
        }

        [HttpPost]
        public IActionResult InsertRegistroVentas([FromBody] RegistroVentas registroVentasService)
        {
            try
            {
                if (registroVentasService == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = _registroVentasService.InsertRegistroVentas(registroVentasService);

                return Created("Creado", created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateRegistroVentas([FromBody] RegistroVentas registroVentasService)
        {
            try
            {
                if (registroVentasService == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _registroVentasService.UpdateRegistroVentas(registroVentasService);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegistroVentas(int id)
        {
            try
            {
                _registroVentasService.DeleteRegistroVentas(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
