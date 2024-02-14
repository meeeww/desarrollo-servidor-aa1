using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService _productosService;

        public ProductosController(ProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            try
            {
                return Ok(_productosService.GetProductos());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los productos." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductoById(int id)
        {
            try
            {
                var cliente = _productosService.GetProductoById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el producto." });
            }
        }

        [HttpPost]
        public IActionResult InsertProducto([FromBody] Producto producto)
        {
            try
            {
                if (producto == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = _productosService.InsertProducto(producto);

                return Created("Creado", created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateProducto([FromBody] Producto producto)
        {
            try
            {
                if (producto == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _productosService.UpdateProducto(producto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            try
            {
                _productosService.DeleteProducto(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
