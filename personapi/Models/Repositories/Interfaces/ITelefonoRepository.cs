﻿using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repositories.Interfaces
{
    public interface ITelefonoRepository
    {
        Task<IEnumerable<Telefono>> GetAllTelefonos();
        Task<Telefono> GetTelefonoById(string num);
        Task AddTelefono(Telefono telefono);
        Task UpdateTelefono(Telefono telefono);
        Task DeleteTelefono(string num);
        Task<IEnumerable<Telefono>> GetTelefonosByDuenio(int duenioId);
    }

}
