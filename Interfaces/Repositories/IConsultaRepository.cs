using VetApi.Models;

namespace VetApi.Interfaces.Repositories
{
    public interface IConsultaRepository : IRepository<ConsultaModel>
    {
        Task<ConsultaModel?> BuscarConsultaDonoVeterinario(int id);
    }
}
