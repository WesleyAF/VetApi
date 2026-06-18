using VetApi.Models;

namespace VetApi.Interfaces.Repositories
{
    public interface IDonoRepository : IRepository<DonoModel>
    {
        Task<DonoModel?> ListAnimalsByOwner(int Id);

    }
}
