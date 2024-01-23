using BankAPI.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankAPI.Data;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService _productosService;
        private readonly ILoggingRepository _logger;

        public ProductosController(ProductosService productosService, ILoggingRepository logger)
        {
            _productosService = productosService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                return Ok(await _productosService.GetProductos());
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoById(int id)
        {
            try
            {
                var producto = await _productosService.GetProductoById(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] Producto producto)
        {
            try
            {
                if (producto == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = await _productosService.InsertProducto(producto);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] Producto producto)
        {
            try
            {
                if (producto == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _productosService.UpdateProducto(producto);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                await _productosService.DeleteProducto(id);

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
