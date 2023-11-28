using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            return Ok(await _pedidoRepository.GetPedidos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            return Ok(await _pedidoRepository.GetPedidoById(id));
        }

        [HttpGet("fecha={fecha}")]
        public async Task<IActionResult> GetPedidoByDate(string fecha)
        {
            if (!DateTime.TryParse(fecha, out DateTime parsedDate))
                return BadRequest("Invalid date format");

            return Ok(await _pedidoRepository.GetPedidoByDate(parsedDate));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePedido([FromBody] Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _pedidoRepository.InsertPedido(pedido);

            return Created("creado", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePedido([FromBody] Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pedidoRepository.UpdatePedido(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            await _pedidoRepository.DeletePedido(new Pedido() { ID_Pedido = id });

            return NoContent();
        }
    }
}
