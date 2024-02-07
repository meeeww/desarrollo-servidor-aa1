using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Data;
using BankAPI.Services;
using System.ComponentModel;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;
        private readonly ILoggingRepository _logger;

        public ClientesController(ClientesService clientesService, ILoggingRepository logger)
        {
            _clientesService = clientesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            try
            {
                return Ok(await _clientesService.GetClientes());
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
                var cliente = await _clientesService.GetClienteById(id);
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
                var cliente = await _clientesService.GetClienteByEmail(email);
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

                var created = await _clientesService.InsertCliente(cliente);

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

                await _clientesService.UpdateCliente(cliente);

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
                await _clientesService.DeleteCliente(id);

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
