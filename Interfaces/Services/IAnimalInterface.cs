using VetApi.Dto.Animal;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Interfaces.Services
{
    public interface IAnimalInterface
    {
        Task<ApiResponse<List<AnimalModel>>> ListarAnimais();
        Task<ApiResponse<AnimalModel>> BuscarAnimalPorId(int id);
        Task<ApiResponse<List<AnimalModel>>> CriarAnimal(CreateAnimalDto createAnimalDto);
        Task<ApiResponse<List<AnimalModel>>> AtualizarAnimal(int Id, UpdateAnimalDto updateAnimalDto);
        Task<ApiResponse<List<AnimalModel>>> DeletarAnimal(int id);
        Task<ApiResponse<List<ConsultaModel>>> ListarConsultasPorAnimal(int animalId);
    }
}
