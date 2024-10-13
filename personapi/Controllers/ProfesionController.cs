using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionController : ControllerBase
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfesiones()
        {
            var profesiones = await _profesionRepository.GetAllProfesiones();
            return Ok(profesiones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfesionById(int id)
        {
            var profesion = await _profesionRepository.GetProfesionById(id);
            if (profesion == null)
                return NotFound();
            return Ok(profesion);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfesion([FromBody] Profesion profesion)
        {
            await _profesionRepository.AddProfesion(profesion);
            return CreatedAtAction(nameof(GetProfesionById), new { id = profesion.Id }, profesion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfesion(int id, [FromBody] Profesion profesion)
        {
            if (id != profesion.Id)
                return BadRequest();
            await _profesionRepository.UpdateProfesion(profesion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            await _profesionRepository.DeleteProfesion(id);
            return NoContent();
        }
    }

}
