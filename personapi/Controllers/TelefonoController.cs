using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("[controller]")]
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        // GET: Telefono
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var telefonos = await _telefonoRepository.GetAllTelefonos();
            return View(telefonos);
        }

        // GET: Telefono/Details/{num}
        [HttpGet("Details/{num}")]
        public async Task<IActionResult> Details(string num)
        {
            var telefono = await _telefonoRepository.GetTelefonoById(num);
            if (telefono == null)
                return NotFound();
            return View(telefono);
        }

        // GET: Telefono/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telefono/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                await _telefonoRepository.AddTelefono(telefono);
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        // GET: Telefono/Edit/{num}
        [HttpGet("Edit/{num}")]
        public async Task<IActionResult> Edit(string num)
        {
            var telefono = await _telefonoRepository.GetTelefonoById(num);
            if (telefono == null)
                return NotFound();
            return View(telefono);
        }

        // POST: Telefono/Edit/{num}
        [HttpPost("Edit/{num}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string num, Telefono telefono)
        {
            if (num != telefono.Num)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _telefonoRepository.UpdateTelefono(telefono);
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        // GET: Telefono/Delete/{num}
        [HttpGet("Delete/{num}")]
        public async Task<IActionResult> Delete(string num)
        {
            var telefono = await _telefonoRepository.GetTelefonoById(num);
            if (telefono == null)
                return NotFound();
            return View(telefono);
        }

        // POST: Telefono/Delete/{num}
        [HttpPost("Delete/{num}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string num)
        {
            var telefono = await _telefonoRepository.GetTelefonoById(num);
            if (telefono == null)
            {
                return NotFound();
            }

            await _telefonoRepository.DeleteTelefono(num);
            return RedirectToAction(nameof(Index));
        }
    }
}