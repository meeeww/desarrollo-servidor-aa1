using BankAPI.Services;
using BankAPI.Model;
using BankAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clienteRepository;
        private readonly ILoggingRepository _logger;

        public ClientesController(IClientesRepository clienteRepository, ILoggingRepository logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                return Ok(await _clienteRepository.GetClientes());
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("email={email}")]
        public async Task<IActionResult> GetClienteByEmail(string email)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteByEmail(email);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = await _clienteRepository.InsertCliente(cliente);

                return Created("creado", created);
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePedido([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _clienteRepository.UpdateCliente(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                await _clienteRepository.DeleteCliente(id);

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
