using BankAPI.Data.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosRepository _empleadoRepository;

        public EmpleadosController(IEmpleadosRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleaados()
        {
            return Ok(await _empleadoRepository.GetEmpleados());
        }
    }
}
