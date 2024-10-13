using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            var personas = await _personaRepository.GetAllPersonas();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonaById(int id)
        {
            var persona = await _personaRepository.GetPersonaById(id);
            if (persona == null)
                return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersona([FromBody] Persona persona)
        {
            await _personaRepository.AddPersona(persona);
            return CreatedAtAction(nameof(GetPersonaById), new { id = persona.Cc }, persona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersona(int id, [FromBody] Persona persona)
        {
            if (id != persona.Cc)
                return BadRequest();
            await _personaRepository.UpdatePersona(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            await _personaRepository.DeletePersona(id);
            return NoContent();
        }
    }

}

