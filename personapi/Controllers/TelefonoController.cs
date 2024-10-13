using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTelefonos()
        {
            var telefonos = await _telefonoRepository.GetAllTelefonos();
            return Ok(telefonos);
        }

        [HttpGet("{num}")]
        public async Task<IActionResult> GetTelefonoById(string num)
        {
            var telefono = await _telefonoRepository.GetTelefonoById(num);
            if (telefono == null)
                return NotFound();
            return Ok(telefono);
        }

        [HttpPost]
        public async Task<IActionResult> AddTelefono([FromBody] Telefono telefono)
        {
            await _telefonoRepository.AddTelefono(telefono);
            return CreatedAtAction(nameof(GetTelefonoById), new { num = telefono.Num }, telefono);
        }

        [HttpPut("{num}")]
        public async Task<IActionResult> UpdateTelefono(string num, [FromBody] Telefono telefono)
        {
            if (num != telefono.Num)
                return BadRequest();
            await _telefonoRepository.UpdateTelefono(telefono);
            return NoContent();
        }

        [HttpDelete("{num}")]
        public async Task<IActionResult> DeleteTelefono(string num)
        {
            await _telefonoRepository.DeleteTelefono(num);
            return NoContent();
        }
    }

}
