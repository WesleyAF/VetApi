using VetApi.Models;

namespace VetApi.Interfaces.Repositories
{
    public interface IAnimalRepository : IRepository<AnimalModel>
    {
        Task<AnimalModel?> ListConsultasByAnimal(int Id);
    }
}
