using VetApi.Dto.Animal;
using VetApi.Models;
using VetApi.Responses;

namespace VetApi.Interfaces.Services
{
    public interface IAnimalInterface
    {
        Task<ApiResponse<List<AnimaisDto>>> ListarAnimais();
        Task<ApiResponse<AnimaisDto>> BuscarAnimalPorId(int id);
        Task<ApiResponse<AnimaisDto>> CriarAnimal(CreateAnimalDto createAnimalDto);
        Task<ApiResponse<AnimaisDto>> AtualizarAnimal(int Id, UpdateAnimalDto updateAnimalDto);
        Task<ApiResponse<AnimaisDto>> DeletarAnimal(int id);
        Task<ApiResponse<AnimalModel>> ListarConsultasPorAnimal(int animalId);
    }
}
