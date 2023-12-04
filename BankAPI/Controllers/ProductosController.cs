using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepository _productoRepository;

        public ProductosController(IProductosRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            return Ok(await _productoRepository.GetProductos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoById(int id)
        {
            return Ok(await _productoRepository.GetProductoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _productoRepository.InsertProducto(producto);

            return Created("creado", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productoRepository.UpdateProducto(producto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _productoRepository.DeleteProducto(new Producto() { ID_Producto = id });

            return NoContent();
        }
    }
}
