using BankAPI.Data;
using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidosService : ControllerBase
    {
        private readonly DetallePedidosService _detallePedidosService;

        public DetallePedidosService(DetallePedidosService detallePedidosService)
        {
            _detallePedidosService = detallePedidosService;
        }

        [HttpGet]
        public IActionResult GetDetallePedidos()
        {
            try
            {
                return Ok(_detallePedidosService.GetDetallePedidos());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los registro de ventas." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDetallePedidosById(int id)
        {
            try
            {
                var cliente = _detallePedidosService.GetDetallePedidosById(id);
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
        public IActionResult InsertDetallePedidos([FromBody] DetallePedido detallePedidosService)
        {
            try
            {
                if (detallePedidosService == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = _detallePedidosService.InsertDetallePedidos(detallePedidosService);

                return Created("Creado", created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateDetallePedidos([FromBody] DetallePedido detallePedidosService)
        {
            try
            {
                if (detallePedidosService == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _detallePedidosService.UpdateDetallePedidos(detallePedidosService);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDetallePedidos(int id)
        {
            try
            {
                _detallePedidosService.DeleteDetallePedidos(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
