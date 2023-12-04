using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clienteRepository;

        public ClientesController(IClientesRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            return Ok(await _clienteRepository.GetClientes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            return Ok(await _clienteRepository.GetClienteById(id));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetClienteByEmail(string email)
        {
            return Ok(await _clienteRepository.GetClienteByEmail(email));
        }


        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _clienteRepository.InsertCliente(cliente);

            return Created("creado", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePedido([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clienteRepository.UpdateCliente(cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            await _clienteRepository.DeleteCliente(new Cliente() { ID_Cliente = id });

            return NoContent();
        }
    }
}
