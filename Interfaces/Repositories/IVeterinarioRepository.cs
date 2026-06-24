using VetApi.Models;

namespace VetApi.Interfaces.Repositories
{
    public interface IVeterinarioRepository : IRepository<VeterinarioModel>
    {
        Task<VeterinarioModel> GetVeterinariosWithConsultas(int veterinarioId);
    }
}
