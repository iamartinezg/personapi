using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repositories.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllPersonas();
        Task<Persona> GetPersonaById(int id);
        Task AddPersona(Persona persona);
        Task UpdatePersona(Persona persona);
        Task DeletePersona(int id);
    }

}
