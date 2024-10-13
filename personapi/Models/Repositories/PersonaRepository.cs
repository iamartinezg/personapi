using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly MasterContext _context;

        public PersonaRepository(MasterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetPersonaById(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task AddPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersona(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }

}
