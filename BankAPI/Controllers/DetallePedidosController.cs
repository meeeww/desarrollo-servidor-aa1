using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidosController : ControllerBase
    {
        private readonly IDetallePedidosRepository _detallePedidoRepository;

        public DetallePedidosController(IDetallePedidosRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetallesPedido()
        {
            return Ok(await _detallePedidoRepository.GetDetallesPedido());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetallePedidoById(int id)
        {
            return Ok(await _detallePedidoRepository.GetDetallePedidoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertDetallePedido([FromBody] DetallePedido detallePedido)
        {
            if (detallePedido == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _detallePedidoRepository.InsertDetallePedido(detallePedido);

            return Created("creado", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDetallePedido([FromBody] DetallePedido detallePedido)
        {
            if (detallePedido == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _detallePedidoRepository.UpdateDetallePedido(detallePedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            await _detallePedidoRepository.DeleteDetallePedido(new DetallePedido() { ID_DetallePedido = id });

            return NoContent();
        }
    }
}
