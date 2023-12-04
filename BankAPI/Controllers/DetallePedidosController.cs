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
    }
}
