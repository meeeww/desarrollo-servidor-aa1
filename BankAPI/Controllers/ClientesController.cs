﻿using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clienteRepository;
        Logging logger = new Logging();

        public ClientesController(IClientesRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
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
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            try
            {
                return Ok(await _clienteRepository.GetClienteById(id));

            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("email={email}")]
        public async Task<IActionResult> GetClienteByEmail(string email)
        {
            try
            {
                return Ok(await _clienteRepository.GetClienteByEmail(email));

            }
            catch (Exception ex)
            {
                logger.SaveLog(ex);
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
                logger.SaveLog(ex);
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
                logger.SaveLog(ex);
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
                logger.SaveLog(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
