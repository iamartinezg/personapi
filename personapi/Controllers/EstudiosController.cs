using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("[controller]")]
    public class EstudiosController : Controller
    {
        private readonly IEstudiosRepository _estudiosRepository;

        public EstudiosController(IEstudiosRepository estudiosRepository)
        {
            _estudiosRepository = estudiosRepository;
        }

        // GET: Estudios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var estudios = await _estudiosRepository.GetAllEstudios();
            return View(estudios);
        }

        // GET: Estudios/Details/{id_prof}/{cc_per}
        [HttpGet("Details/{id_prof}/{cc_per}")]
        public async Task<IActionResult> Details(int id_prof, int cc_per)
        {
            var estudios = await _estudiosRepository.GetEstudiosById(id_prof, cc_per);
            if (estudios == null)
                return NotFound();
            return View(estudios);
        }

        // GET: Estudios/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudios/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Estudios estudios)
        {
            if (ModelState.IsValid)
            {
                await _estudiosRepository.AddEstudios(estudios);
                return RedirectToAction(nameof(Index));
            }
            return View(estudios);
        }

        // GET: Estudios/Edit/{id_prof}/{cc_per}
        [HttpGet("Edit/{id_prof}/{cc_per}")]
        public async Task<IActionResult> Edit(int id_prof, int cc_per)
        {
            var estudios = await _estudiosRepository.GetEstudiosById(id_prof, cc_per);
            if (estudios == null)
                return NotFound();
            return View(estudios);
        }

        // POST: Estudios/Edit/{id_prof}/{cc_per}
        [HttpPost("Edit/{id_prof}/{cc_per}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id_prof, int cc_per, Estudios estudios)
        {
            if (id_prof != estudios.IdProf || cc_per != estudios.CcPer)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _estudiosRepository.UpdateEstudios(estudios);
                return RedirectToAction(nameof(Index));
            }
            return View(estudios);
        }

        // GET: Estudios/Delete/{id_prof}/{cc_per}
        [HttpGet("Delete/{id_prof}/{cc_per}")]
        public async Task<IActionResult> Delete(int id_prof, int cc_per)
        {
            var estudios = await _estudiosRepository.GetEstudiosById(id_prof, cc_per);
            if (estudios == null)
                return NotFound();
            return View(estudios);
        }

        // POST: Estudios/Delete/{id_prof}/{cc_per}
        [HttpPost("Delete/{id_prof}/{cc_per}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id_prof, int cc_per)
        {
            await _estudiosRepository.DeleteEstudios(id_prof, cc_per);
            return RedirectToAction(nameof(Index));
        }
    }
}