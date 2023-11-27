using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await _usuarioRepository.GetUsuarios());
        }

        [HttpGet("id={id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            return Ok(await _usuarioRepository.GetUsuarioById(id));
        }

        [HttpGet("dni={dni}")]
        public async Task<IActionResult> GetUsuarioByDNI(string DNI)
        {
            return Ok(await _usuarioRepository.GetUsuarioByDNI(DNI));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _usuarioRepository.InsertUsuario(usuario);

            return Created("creado", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarioRepository.UpdateUsuario(usuario);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioRepository.DeleteUsuario(new Usuario() { id_usuario = id });

            return NoContent();
        }
    }
}
