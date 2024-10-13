using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repositories.Interfaces
{
    public interface IEstudiosRepository
    {
        Task<IEnumerable<Estudios>> GetAllEstudios();
        Task<Estudios> GetEstudiosById(int id_prof, int cc_per);
        Task AddEstudios(Estudios estudios);
        Task UpdateEstudios(Estudios estudios);
        Task DeleteEstudios(int id_prof, int cc_per);
        
    }

}
