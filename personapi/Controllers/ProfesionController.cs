using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("[controller]")]
    public class ProfesionController : Controller
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        // GET: Profesion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var profesiones = await _profesionRepository.GetAllProfesiones();
            return View(profesiones);
        }

        // GET: Profesion/Details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var profesion = await _profesionRepository.GetProfesionById(id);
            if (profesion == null)
                return NotFound();
            return View(profesion);
        }

        // GET: Profesion/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesion/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                await _profesionRepository.AddProfesion(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: Profesion/Edit/{id}
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var profesion = await _profesionRepository.GetProfesionById(id);
            if (profesion == null)
                return NotFound();
            return View(profesion);
        }

        // POST: Profesion/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Profesion profesion)
        {
            if (id != profesion.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _profesionRepository.UpdateProfesion(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: Profesion/Delete/{id}
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profesion = await _profesionRepository.GetProfesionById(id);
            if (profesion == null)
                return NotFound();
            return View(profesion);
        }

        // POST: Profesion/Delete/{id}
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _profesionRepository.DeleteProfesion(id);
            return RedirectToAction(nameof(Index));
        }
    }
}