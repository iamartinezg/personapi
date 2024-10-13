using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repositories.Interfaces
{
    public interface IProfesionRepository
    {
        Task<IEnumerable<Profesion>> GetAllProfesiones();
        Task<Profesion> GetProfesionById(int id);
        Task AddProfesion(Profesion profesion);
        Task UpdateProfesion(Profesion profesion);
        Task DeleteProfesion(int id);
    }

}
