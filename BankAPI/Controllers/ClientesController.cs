using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            try
            {
                return Ok(_clientesService.GetClientes());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los clientes.", error = ex.ToString() });
            }
        }

         [HttpGet("{id}")]
         public IActionResult GetClienteById(int id)
         {
             try
             {
                 var cliente = _clientesService.GetClienteById(id);
                 if (cliente == null)
                 {
                     return NotFound();
                 }
                 return Ok(cliente);

             }
             catch (Exception ex)
             {
                 return BadRequest(new { message = "Ocurrió un error al obtener los clientes." });
             }
         }

         [HttpGet("email={email}")]
         public IActionResult GetClienteByEmail(string email)
         {
             try
             {
                 var cliente = _clientesService.GetClienteByEmail(email);
                 if (cliente == null)
                 {
                     return NotFound();
                 }
                 return Ok(cliente);

             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }
         }


         [HttpPost]
         public IActionResult InsertCliente([FromBody] Cliente cliente)
         {
             try
             {
                 if (cliente == null)
                     return BadRequest();

                 if (!ModelState.IsValid)
                     return BadRequest(ModelState);

                 var created = _clientesService.InsertCliente(cliente);

                 return Created("Creado", created);
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }
         }

         [HttpPut]
         public IActionResult UpdatePedido([FromBody] Cliente cliente)
         {
             try
             {
                 if (cliente == null)
                     return BadRequest();

                 if (!ModelState.IsValid)
                     return BadRequest(ModelState);

                 _clientesService.UpdateCliente(cliente);

                 return NoContent();
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }
         }

         [HttpDelete("{id}")]
         public IActionResult DeleteCliente(int id)
         {
             try
             {
                 _clientesService.DeleteCliente(id);

                 return NoContent();
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }
         }
    }
}
