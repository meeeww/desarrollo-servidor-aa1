using BankAPI.Data;
using BankAPI.Model;
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
        private readonly ILoggingRepository _logger;

        public DetallePedidosController(DetallePedidosService detallePedidosService, ILoggingRepository logger)
        {
            _detallePedidosService = detallePedidosService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetallesPedido()
        {
            return Ok(await _detallePedidosService.GetDetallesPedido());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetallePedidoById(int id)
        {

            try
            {
                var detallePedido = await _detallePedidosService.GetDetallePedidoById(id);
                if (detallePedido == null)
                {
                    return NotFound();
                }
                return Ok(detallePedido);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
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

                var created = await _detallePedidosService.InsertDetallePedido(detallePedido);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
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

                await _detallePedidosService.UpdateDetallePedido(detallePedido);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {

            try
            {
                _detallePedidosService.DeleteDetallePedidos(id);

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
