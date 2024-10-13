using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly DbContext _context;

        public ProfesionRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesion>> GetAllProfesiones()
        {
            return await _context.Profesiones.ToListAsync();
        }

        public async Task<Profesion> GetProfesionById(int id)
        {
            return await _context.Profesiones.FindAsync(id);
        }

        public async Task AddProfesion(Profesion profesion)
        {
            _context.Profesiones.Add(profesion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfesion(Profesion profesion)
        {
            _context.Entry(profesion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesion(int id)
        {
            var profesion = await _context.Profesiones.FindAsync(id);
            if (profesion != null)
            {
                _context.Profesiones.Remove(profesion);
                await _context.SaveChangesAsync();
            }
        }
    }

}
