using BankAPI.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Data;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosService _pedidosService;
        private readonly ILoggingRepository _logger;

        public PedidosController(PedidosService pedidosService, ILoggingRepository logger)
        {
            _pedidosService = pedidosService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            try
            {
                return Ok(await _pedidosService.GetPedidos());
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            try
            {
                var pedido = await _pedidosService.GetPedidoById(id);
                if (pedido == null)
                {
                    return NotFound();
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("fecha={fecha}")]
        public async Task<IActionResult> GetPedidoByDate(string fecha)
        {
            try
            {
                if (!DateTime.TryParse(fecha, out DateTime parsedDate))
                    return BadRequest("Invalid date format");

                var pedido = await _pedidosService.GetPedidoByDate(parsedDate);
                if (pedido == null)
                {
                    return NotFound();
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePedido([FromBody] Pedido pedido)
        {
            try
            {
                if (pedido == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = await _pedidosService.InsertPedido(pedido);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePedido([FromBody] Pedido pedido)
        {
            try
            {
                if (pedido == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _pedidosService.UpdatePedido(pedido);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            try
            {
                await _pedidosService.DeletePedido(id);

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
