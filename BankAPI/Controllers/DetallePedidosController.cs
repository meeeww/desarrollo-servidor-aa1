using BankAPI.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Data;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidosController : ControllerBase
    {
        private readonly DetallePedidosService _detallePedidosService;

        public DetallePedidosController(DetallePedidosService detallePedidosService)
        {
            _detallePedidosService = detallePedidosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetallesPedido()
        {
            return Ok(_detallePedidosService.GetDetallesPedido());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetallePedidoById(int id)
        {

            try
            {
                var detallePedido = _detallePedidosService.GetDetallePedidoById(id);
                if (detallePedido == null)
                {
                    return NotFound();
                }
                return Ok(detallePedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertDetallePedido([FromBody] DetallePedido detallePedido)
        {

            try
            {
                if (detallePedido == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = _detallePedidosService.InsertDetallePedido(detallePedido);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDetallePedido([FromBody] DetallePedido detallePedido)
        {

            try
            {
                if (detallePedido == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _detallePedidosService.UpdateDetallePedido(detallePedido);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {

            try
            {
                _detallePedidosService.DeleteDetallePedido(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
