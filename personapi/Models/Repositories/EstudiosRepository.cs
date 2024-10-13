using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Repositories.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private readonly DbContext _context;

        public EstudiosRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudios>> GetAllEstudios()
        {
            return await _context.Estudios.ToListAsync();
        }

        public async Task<Estudios> GetEstudiosById(int id_prof, int cc_per)
        {
            return await _context.Estudios.FindAsync(id_prof, cc_per);
        }

        public async Task AddEstudios(Estudios estudios)
        {
            _context.Estudios.Add(estudios);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstudios(Estudios estudios)
        {
            _context.Entry(estudios).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstudios(int id_prof, int cc_per)
        {
            var estudios = await _context.Estudios.FindAsync(id_prof, cc_per);
            if (estudios != null)
            {
                _context.Estudios.Remove(estudios);
                await _context.SaveChangesAsync();
            }
        }
    }

}
