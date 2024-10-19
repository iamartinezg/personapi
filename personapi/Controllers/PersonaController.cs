using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("[controller]")]
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly ITelefonoRepository _telefonoRepository;

        public PersonaController(IPersonaRepository personaRepository, ITelefonoRepository telefonoRepository)
        {
            _personaRepository = personaRepository;
            _telefonoRepository = telefonoRepository;
        }

        // GET: Persona
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var personas = await _personaRepository.GetAllPersonas();
            return View(personas);
        }

        // GET: Persona/Details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var persona = await _personaRepository.GetPersonaById(id);
            if (persona == null)
                return NotFound();
            return View(persona);
        }

        // GET: Persona/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                await _personaRepository.AddPersona(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Persona/Edit/{id}
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var persona = await _personaRepository.GetPersonaById(id);
            if (persona == null)
                return NotFound();
            return View(persona);
        }

        // POST: Persona/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Persona persona)
        {
            if (id != persona.Cc)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _personaRepository.UpdatePersona(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Persona/Delete/{id}
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _personaRepository.GetPersonaById(id);
            if (persona == null)
                return NotFound();
            return View(persona);
        }

        // POST: Persona/Delete/{id}
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Verificar si hay teléfonos asociados a la persona
            var telefonos = await _telefonoRepository.GetTelefonosByDuenio(id);
            if (telefonos.Any())
            {
                ModelState.AddModelError("", "No se puede eliminar la persona, ya que tiene teléfonos asociados.");
                var persona = await _personaRepository.GetPersonaById(id);
                return View("Delete", persona); // Asegúrate de devolver la vista "Delete" con el modelo
            }

            // Si no hay teléfonos asociados, eliminar la persona
            await _personaRepository.DeletePersona(id);
            return RedirectToAction(nameof(Index));
        }
    }
}