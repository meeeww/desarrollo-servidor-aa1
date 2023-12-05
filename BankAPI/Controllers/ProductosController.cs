using BankAPI.Data.Repositories;
using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepository _productoRepository;
        Logging logger = new Logging();

        public ProductosController(IProductosRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                return Ok(await _productoRepository.GetProductos());
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoById(int id)
        {
            try
            {
                return Ok(await _productoRepository.GetProductoById(id));
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
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

                var created = await _productoRepository.InsertProducto(producto);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
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

                await _productoRepository.UpdateProducto(producto);

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                await _productoRepository.DeleteProducto(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
