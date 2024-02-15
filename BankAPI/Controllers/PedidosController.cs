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

        public PedidosController(PedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            try
            {
                return Ok(_pedidosService.GetPedidos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            try
            {
                var pedido = _pedidosService.GetPedidoById(id);
                if (pedido == null)
                {
                    return NotFound();
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {
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

                var pedido = _pedidosService.GetPedidoByDate(parsedDate);
                if (pedido == null)
                {
                    return NotFound();
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {
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

                var created = _pedidosService.InsertPedido(pedido);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
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

                _pedidosService.UpdatePedido(pedido);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            try
            {
                _pedidosService.DeletePedido(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
