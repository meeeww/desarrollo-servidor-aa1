using BankAPI.Data.Services;
using BankAPI.Model;
using BankAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidosController : ControllerBase
    {
        private readonly IDetallePedidosRepository _detallePedidoRepository;
        private readonly ILoggingRepository _logger;

        public DetallePedidosController(IDetallePedidosRepository detallePedidoRepository, ILoggingRepository logger)
        {
            _detallePedidoRepository = detallePedidoRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetallesPedido()
        {
            return Ok(await _detallePedidoRepository.GetDetallesPedido());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetallePedidoById(int id)
        {

            try
            {
                return Ok(await _detallePedidoRepository.GetDetallePedidoById(id));
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

                var created = await _detallePedidoRepository.InsertDetallePedido(detallePedido);

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

                await _detallePedidoRepository.UpdateDetallePedido(detallePedido);

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
                await _detallePedidoRepository.DeleteDetallePedido(id);

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
