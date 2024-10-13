using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private readonly IEstudiosRepository _estudiosRepository;

        public EstudiosController(IEstudiosRepository estudiosRepository)
        {
            _estudiosRepository = estudiosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstudios()
        {
            var estudios = await _estudiosRepository.GetAllEstudios();
            return Ok(estudios);
        }

        [HttpGet("{id_prof}/{cc_per}")]
        public async Task<IActionResult> GetEstudiosById(int id_prof, int cc_per)
        {
            var estudios = await _estudiosRepository.GetEstudiosById(id_prof, cc_per);
            if (estudios == null)
                return NotFound();
            return Ok(estudios);
        }

        [HttpPost]
        public async Task<IActionResult> AddEstudios([FromBody] Estudios estudios)
        {
            await _estudiosRepository.AddEstudios(estudios);
            return CreatedAtAction(nameof(GetEstudiosById), new { id_prof = estudios.IdProf, cc_per = estudios.CcPer }, estudios);
        }

        [HttpPut("{id_prof}/{cc_per}")]
        public async Task<IActionResult> UpdateEstudios(int id_prof, int cc_per, [FromBody] Estudios estudios)
        {
            if (id_prof != estudios.IdProf || cc_per != estudios.CcPer)
                return BadRequest();
            await _estudiosRepository.UpdateEstudios(estudios);
            return NoContent();
        }

        [HttpDelete("{id_prof}/{cc_per}")]
        public async Task<IActionResult> DeleteEstudios(int id_prof, int cc_per)
        {
            await _estudiosRepository.DeleteEstudios(id_prof, cc_per);
            return NoContent();
        }
    }

}
